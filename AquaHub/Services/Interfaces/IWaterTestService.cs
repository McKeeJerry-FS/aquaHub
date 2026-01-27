using System;
using AquaHub.Models;

namespace AquaHub.Services.Interfaces;

public interface IWaterTestService
{
    Task<List<WaterTest>> GetAllWaterTestsAsync(string userId);
    Task<List<WaterTest>> GetWaterTestsByTankAsync(int tankId, string userId);
    Task<WaterTest?> GetWaterTestByIdAsync(int id, string userId);
    Task<WaterTest> CreateWaterTestAsync(WaterTest waterTest, int tankId, string userId);
    Task<WaterTest> UpdateWaterTestAsync(WaterTest waterTest, string userId);
    Task<bool> DeleteWaterTestAsync(int id, string userId);
}
