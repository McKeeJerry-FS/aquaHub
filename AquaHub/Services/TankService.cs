using System;
using AquaHub.Data;
using AquaHub.Models;
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
}
