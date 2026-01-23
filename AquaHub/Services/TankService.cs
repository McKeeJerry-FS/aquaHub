using System;
using AquaHub.Data;
using AquaHub.Models;
using AquaHub.Models.ViewModels;
using AquaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

public class TankService : ITankService
{
    private readonly ApplicationDbContext _context;
    private readonly IFileUploadService _fileUploadService;

    public TankService(ApplicationDbContext context, IFileUploadService fileUploadService)
    {
        _context = context;
        _fileUploadService = fileUploadService;
    }

    public async Task<List<Tank>> GetAllTanksAsync(string userId)
    {
        return await _context.Tanks
            .Where(t => t.UserId == userId)
            .Include(t => t.WaterTests)
            .Include(t => t.Livestock)
            .Include(t => t.Equipment)
            .Include(t => t.MaintenanceLogs)
            .ToListAsync();
    }

    public async Task<Tank?> GetTankByIdAsync(int id, string userId)
    {
        return await _context.Tanks
            .Where(t => t.UserId == userId)
            .Include(t => t.WaterTests)
            .Include(t => t.Livestock)
            .Include(t => t.Equipment)
            .Include(t => t.MaintenanceLogs)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tank> CreateTankAsync(Tank tank, string userId)
    {
        tank.UserId = userId;
        _context.Tanks.Add(tank);
        await _context.SaveChangesAsync();
        return tank;
    }

    public async Task<Tank> UpdateTankAsync(Tank tank, string userId)
    {
        // Verify ownership
        var existingTank = await _context.Tanks
            .FirstOrDefaultAsync(t => t.Id == tank.Id && t.UserId == userId);

        if (existingTank == null)
        {
            throw new UnauthorizedAccessException("You don't have permission to update this tank.");
        }

        existingTank.Name = tank.Name;
        existingTank.VolumeGallons = tank.VolumeGallons;
        existingTank.Type = tank.Type;
        existingTank.StartDate = tank.StartDate;
        existingTank.Notes = tank.Notes;
        existingTank.ImagePath = tank.ImagePath;

        await _context.SaveChangesAsync();
        return existingTank;
    }

    public async Task<bool> DeleteTankAsync(int id, string userId)
    {
        var tank = await _context.Tanks
            .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

        if (tank == null) return false;

        // Delete associated image if exists
        if (!string.IsNullOrEmpty(tank.ImagePath))
        {
            await _fileUploadService.DeleteImageAsync(tank.ImagePath);
        }

        _context.Tanks.Remove(tank);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TankDashboardViewModel> GetTankDashboardAsync(int tankId, string userId, int month, int year)
    {
        var tank = await _context.Tanks
            .Where(t => t.Id == tankId && t.UserId == userId)
            .Include(t => t.WaterTests)
            .Include(t => t.Livestock)
            .Include(t => t.Equipment)
            .Include(t => t.MaintenanceLogs)
            .FirstOrDefaultAsync();

        if (tank == null)
        {
            return new TankDashboardViewModel();
        }

        var viewModel = new TankDashboardViewModel
        {
            Tank = tank,
            SelectedMonth = month,
            SelectedYear = year
        };

        // Get most recent water test
        viewModel.MostRecentWaterTest = tank.WaterTests
            .OrderByDescending(wt => wt.Timestamp)
            .FirstOrDefault();

        // Get water tests for selected month
        var startDate = new DateTime(year, month, 1);
        var endDate = startDate.AddMonths(1);

        var monthTests = tank.WaterTests
            .Where(wt => wt.Timestamp >= startDate && wt.Timestamp < endDate)
            .OrderBy(wt => wt.Timestamp)
            .ToList();

        // Build chart data
        viewModel.ChartLabels = monthTests.Select(wt => wt.Timestamp.ToString("MMM dd")).ToList();
        viewModel.PHData = monthTests.Select(wt => wt.PH).ToList();
        viewModel.TemperatureData = monthTests.Select(wt => wt.Temperature).ToList();
        viewModel.AmmoniaData = monthTests.Select(wt => wt.Ammonia).ToList();
        viewModel.NitriteData = monthTests.Select(wt => wt.Nitrite).ToList();
        viewModel.NitrateData = monthTests.Select(wt => wt.Nitrate).ToList();

        // Reef-specific
        viewModel.SalinityData = monthTests.Select(wt => wt.Salinity).ToList();
        viewModel.AlkalinityData = monthTests.Select(wt => wt.Alkalinity).ToList();
        viewModel.CalciumData = monthTests.Select(wt => wt.Calcium).ToList();
        viewModel.MagnesiumData = monthTests.Select(wt => wt.Magnesium).ToList();
        viewModel.PhosphateData = monthTests.Select(wt => wt.Phosphate).ToList();

        // Freshwater-specific
        viewModel.GHData = monthTests.Select(wt => wt.GH).ToList();
        viewModel.KHData = monthTests.Select(wt => wt.KH).ToList();
        viewModel.TDSData = monthTests.Select(wt => wt.TDS).ToList();

        // Build available months dropdown
        var allTests = tank.WaterTests.OrderBy(wt => wt.Timestamp).ToList();
        if (allTests.Any())
        {
            var firstTest = allTests.First().Timestamp;
            var lastTest = allTests.Last().Timestamp;

            var current = new DateTime(firstTest.Year, firstTest.Month, 1);
            var end = new DateTime(lastTest.Year, lastTest.Month, 1);

            while (current <= end)
            {
                viewModel.AvailableMonths.Add(new MonthYearOption
                {
                    Month = current.Month,
                    Year = current.Year,
                    DisplayText = current.ToString("MMMM yyyy")
                });
                current = current.AddMonths(1);
            }
        }

        // Get equipment needing maintenance (example: installed > 6 months ago)
        var sixMonthsAgo = DateTime.Now.AddMonths(-6);
        viewModel.EquipmentNeedingMaintenance = tank.Equipment
            .Where(e => e.InstalledOn < sixMonthsAgo)
            .ToList();

        // Recent maintenance
        viewModel.RecentMaintenance = tank.MaintenanceLogs
            .OrderByDescending(m => m.Timestamp)
            .Take(5)
            .ToList();

        return viewModel;
    }
}
