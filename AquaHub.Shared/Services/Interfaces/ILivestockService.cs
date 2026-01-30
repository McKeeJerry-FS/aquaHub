using System;
using AquaHub.Shared.Models;
using AquaHub.Shared.Models.ViewModels;

namespace AquaHub.Shared.Services.Interfaces;

public interface ILivestockService
{
    Task<List<Livestock>> GetAllLivestockAsync(string userId);
    Task<List<Livestock>> GetLivestockByTankAsync(int tankId, string userId);
    Task<Livestock?> GetLivestockByIdAsync(int id, string userId);
    Task<Livestock> CreateLivestockAsync(Livestock livestock, int tankId, string userId);
    Task<Livestock> UpdateLivestockAsync(Livestock livestock, string userId);
    Task<bool> DeleteLivestockAsync(int id, string userId);
    Task<LivestockDashboardViewModel> GetLivestockDashboardAsync(int livestockId, string userId);
}
