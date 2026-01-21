using System;
using AquaHub.Models;
using AquaHub.Services.Interfaces;

namespace AquaHub.Services;

public class TankService : ITankService
{
    public Task<Tank> CreateTankAsync(Tank tank)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTankAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tank>> GetAllTanksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tank?> GetTankByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Tank> UpdateTankAsync(Tank tank)
    {
        throw new NotImplementedException();
    }
}
