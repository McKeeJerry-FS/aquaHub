using System;
using AquaHub.Data;
using AquaHub.Models;
using AquaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

public class TankService : ITankService
{
    private readonly ApplicationDbContext _context;

    public TankService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Tank> CreateTankAsync(Tank tank)
    {
         _context.Tanks.Add(tank);
        await _context.SaveChangesAsync();
        return tank;
    }
  
    public async Task<bool> DeleteTankAsync(int id)
    {
        var tank = await _context.Tanks.FindAsync(id);
        if (tank == null) return false;

        _context.Tanks.Remove(tank);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Tank>> GetAllTanksAsync()
    {
        return await _context.Tanks.Include(t => t.WaterTests)
            .Include(t => t.Livestock)
            .Include(t => t.Equipment)
            .Include(t => t.MaintenanceLogs)
            .ToListAsync();
    }

    public async Task<Tank?> GetTankByIdAsync(int id)
    {
        return await _context.Tanks.Include(t => t.WaterTests)
            .Include(t => t.WaterTests)
            .Include(t => t.Livestock)
            .Include(t => t.Equipment)
            .Include(t => t.MaintenanceLogs)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tank> UpdateTankAsync(Tank tank)
    {
        _context.Tanks.Update(tank);
        await _context.SaveChangesAsync();
        return tank;
    }
}
