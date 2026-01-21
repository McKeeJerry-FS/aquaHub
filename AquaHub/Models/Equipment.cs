using System;
using System.ComponentModel.DataAnnotations;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public abstract class Equipment
{
    public int Id { get; set; }
    public int TankId { get; set; }
    public Tank? Tank { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime InstalledOn { get; set; }
}
