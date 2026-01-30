using System;
using AquaHub.Shared.Models;

namespace AquaHub.Shared.Services.Interfaces;

public interface IMaintenanceLogService
{
    Task<List<MaintenanceLog>> GetAllMaintenanceLogsAsync(string userId);
    Task<List<MaintenanceLog>> GetMaintenanceLogsByTankAsync(int tankId, string userId);
    Task<MaintenanceLog?> GetMaintenanceLogByIdAsync(int id, string userId);
    Task<MaintenanceLog> CreateMaintenanceLogAsync(MaintenanceLog maintenanceLog, int tankId, string userId);
    Task<MaintenanceLog> UpdateMaintenanceLogAsync(MaintenanceLog maintenanceLog, string userId);
    Task<bool> DeleteMaintenanceLogAsync(int id, string userId);
}
