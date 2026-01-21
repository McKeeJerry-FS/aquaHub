using System;
using AquaHub.Models;

namespace AquaHub.Services.Interfaces;

public interface ITankService
{
    Task<List<Tank>> GetAllTanksAsync();
    Task<Tank?> GetTankByIdAsync(int id);
    Task<Tank> CreateTankAsync(Tank tank);
    Task<Tank> UpdateTankAsync(Tank tank);
    Task<bool> DeleteTankAsync(int id);
}
