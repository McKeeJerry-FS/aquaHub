using System;
using AquaHub.Data;
using AquaHub.Models;
using AquaHub.Models.Enums;
using AquaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

public class WaterTestService : IWaterTestService
{
    private readonly ApplicationDbContext _context;
    private readonly INotificationService? _notificationService;

    public WaterTestService(ApplicationDbContext context, INotificationService? notificationService = null)
    {
        _context = context;
        _notificationService = notificationService;
    }

    public async Task<List<WaterTest>> GetAllWaterTestsAsync(string userId)
    {
        return await _context.WaterTests
            .Include(w => w.Tank)
            .Where(w => w.Tank!.UserId == userId)
            .OrderByDescending(w => w.Timestamp)
            .ToListAsync();
    }

    public async Task<List<WaterTest>> GetWaterTestsByTankAsync(int tankId, string userId)
    {
        return await _context.WaterTests
            .Include(w => w.Tank)
            .Where(w => w.TankId == tankId && w.Tank!.UserId == userId)
            .OrderByDescending(w => w.Timestamp)
            .ToListAsync();
    }

    public async Task<WaterTest?> GetWaterTestByIdAsync(int id, string userId)
    {
        return await _context.WaterTests
            .Include(w => w.Tank)
            .Where(w => w.Tank!.UserId == userId)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<WaterTest> CreateWaterTestAsync(WaterTest waterTest, int tankId, string userId)
    {
        // Verify tank ownership
        var tank = await _context.Tanks
            .FirstOrDefaultAsync(t => t.Id == tankId && t.UserId == userId);

        if (tank == null)
        {
            throw new UnauthorizedAccessException("You don't have permission to add water tests to this tank.");
        }

        waterTest.TankId = tankId;
        waterTest.Timestamp = DateTime.UtcNow;

        _context.WaterTests.Add(waterTest);
        await _context.SaveChangesAsync();

        // Check for out-of-range parameters and create notifications
        await CheckWaterParametersAsync(waterTest, tank);

        return waterTest;
    }

    public async Task<WaterTest> UpdateWaterTestAsync(WaterTest waterTest, string userId)
    {
        // Verify ownership through tank
        var existingWaterTest = await _context.WaterTests
            .Include(w => w.Tank)
            .FirstOrDefaultAsync(w => w.Id == waterTest.Id && w.Tank!.UserId == userId);

        if (existingWaterTest == null)
        {
            throw new UnauthorizedAccessException("You don't have permission to update this water test.");
        }

        // Update properties
        existingWaterTest.PH = waterTest.PH;
        existingWaterTest.Temperature = waterTest.Temperature;
        existingWaterTest.Ammonia = waterTest.Ammonia;
        existingWaterTest.Nitrite = waterTest.Nitrite;
        existingWaterTest.Nitrate = waterTest.Nitrate;
        existingWaterTest.GH = waterTest.GH;
        existingWaterTest.KH = waterTest.KH;
        existingWaterTest.TDS = waterTest.TDS;
        existingWaterTest.Salinity = waterTest.Salinity;
        existingWaterTest.Alkalinity = waterTest.Alkalinity;
        existingWaterTest.Calcium = waterTest.Calcium;
        existingWaterTest.Magnesium = waterTest.Magnesium;

        // Check for out-of-range parameters after update
        await CheckWaterParametersAsync(existingWaterTest, existingWaterTest.Tank!);

        existingWaterTest.Phosphate = waterTest.Phosphate;

        await _context.SaveChangesAsync();
        return existingWaterTest;
    }

    public async Task<bool> DeleteWaterTestAsync(int id, string userId)
    {
        var waterTest = await _context.WaterTests
            .Include(w => w.Tank)
            .FirstOrDefaultAsync(w => w.Id == id && w.Tank!.UserId == userId);

        if (waterTest == null) return false;

        _context.WaterTests.Remove(waterTest);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task CheckWaterParametersAsync(WaterTest waterTest, Tank tank)
    {
        if (_notificationService == null)
            return;

        var settings = await _notificationService.GetUserSettingsAsync(tank.UserId);
        if (!settings.WaterParameterAlertsEnabled)
            return;

        // Define safe ranges based on tank type
        var isSaltwater = tank.Type == AquariumType.Saltwater || tank.Type == AquariumType.Reef;

        // Check pH
        if (waterTest.PH.HasValue)
        {
            double minPH = isSaltwater ? 8.0 : 6.5;
            double maxPH = isSaltwater ? 8.4 : 8.0;

            if (waterTest.PH.Value < minPH || waterTest.PH.Value > maxPH)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "pH", waterTest.PH.Value, minPH, maxPH);
            }
        }

        // Check Ammonia (should be 0)
        if (waterTest.Ammonia.HasValue && waterTest.Ammonia.Value > 0.25)
        {
            await _notificationService.CreateWaterParameterAlertAsync(
                waterTest, "Ammonia", waterTest.Ammonia.Value, null, 0.25);
        }

        // Check Nitrite (should be 0)
        if (waterTest.Nitrite.HasValue && waterTest.Nitrite.Value > 0.5)
        {
            await _notificationService.CreateWaterParameterAlertAsync(
                waterTest, "Nitrite", waterTest.Nitrite.Value, null, 0.5);
        }

        // Check Nitrate
        if (waterTest.Nitrate.HasValue)
        {
            double maxNitrate = isSaltwater ? 20 : 40;
            if (waterTest.Nitrate.Value > maxNitrate)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Nitrate", waterTest.Nitrate.Value, null, maxNitrate);
            }
        }

        // Check Temperature
        if (waterTest.Temperature.HasValue)
        {
            double minTemp = isSaltwater ? 75 : 72;
            double maxTemp = isSaltwater ? 80 : 82;

            if (waterTest.Temperature.Value < minTemp || waterTest.Temperature.Value > maxTemp)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Temperature", waterTest.Temperature.Value, minTemp, maxTemp);
            }
        }

        // Check Salinity (for saltwater tanks)
        if (isSaltwater && waterTest.Salinity.HasValue)
        {
            if (waterTest.Salinity.Value < 1.023 || waterTest.Salinity.Value > 1.026)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Salinity", waterTest.Salinity.Value, 1.023, 1.026);
            }
        }

        // Check Calcium (for reef tanks)
        if (tank.Type == AquariumType.Reef && waterTest.Calcium.HasValue)
        {
            if (waterTest.Calcium.Value < 380 || waterTest.Calcium.Value > 450)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Calcium", waterTest.Calcium.Value, 380, 450);
            }
        }

        // Check Magnesium (for reef tanks)
        if (tank.Type == AquariumType.Reef && waterTest.Magnesium.HasValue)
        {
            if (waterTest.Magnesium.Value < 1250 || waterTest.Magnesium.Value > 1350)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Magnesium", waterTest.Magnesium.Value, 1250, 1350);
            }
        }

        // Check Phosphate
        if (waterTest.Phosphate.HasValue)
        {
            double maxPhosphate = isSaltwater ? 0.03 : 1.0;
            if (waterTest.Phosphate.Value > maxPhosphate)
            {
                await _notificationService.CreateWaterParameterAlertAsync(
                    waterTest, "Phosphate", waterTest.Phosphate.Value, null, maxPhosphate);
            }
        }
    }
}
