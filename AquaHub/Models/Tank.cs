using System;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public class Tank
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public double VolumeGallons { get; set; } 
    public AquariumType Type { get; set; } 
    public DateTime StartDate { get; set; } 
    public string Notes { get; set; } = string.Empty;
    public ICollection<WaterTest> WaterTests { get; set; } = new List<WaterTest>();
    public ICollection<Livestock> Livestock { get; set; } = new List<Livestock>(); 
    public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    public ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
}

