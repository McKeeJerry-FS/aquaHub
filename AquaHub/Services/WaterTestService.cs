using System;
using AquaHub.Data;
using AquaHub.Models;
using AquaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

public class WaterTestService : IWaterTestService
{
    private readonly ApplicationDbContext _context;

    public WaterTestService(ApplicationDbContext context)
    {
        _context = context;
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
}
