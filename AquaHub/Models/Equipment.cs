using System;
using System.ComponentModel.DataAnnotations;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public class Equipment
{
    [Key]
    public Guid Id { get; set; }
    
    [Display(Name = "Equipment Type")]
    public EquipmentType EquipmentType { get; set; }
    
    [Required]
    [Display(Name = "Equipment Name")]
    public string Name { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public DateTime PurchaseDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
