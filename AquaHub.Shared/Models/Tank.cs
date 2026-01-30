using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AquaHub.Shared.Models.Enums;

namespace AquaHub.Shared.Models;

public class Tank
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tank name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tank name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Volume is required")]
    [Range(1, 10000, ErrorMessage = "Volume must be between 1 and 10,000 gallons")]
    [Display(Name = "Volume (Gallons)")]
    public double VolumeGallons { get; set; }

    [Required(ErrorMessage = "Tank type is required")]
    [Display(Name = "Tank Type")]
    public AquariumType Type { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
    public string Notes { get; set; } = string.Empty;

    // Image path stored relative to wwwroot
    public string? ImagePath { get; set; }

    // User ownership - Required at database level but set by service, not by user input
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public AppUser? User { get; set; }

    public ICollection<WaterTest> WaterTests { get; set; } = new List<WaterTest>();
    public ICollection<Livestock> Livestock { get; set; } = new List<Livestock>();
    public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    public ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
}

