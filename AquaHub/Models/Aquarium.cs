using System;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public class Aquarium
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Tank? VolumeLiters { get; set; }
    public Tank? Length { get; set; }
    public Tank? Width { get; set; }
    public Tank? Height { get; set; }
    public AquariumType Type { get; set; }
    public AquariumSubstrate Substrate { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public IEnumerable<Equipment> AquariumEquipment { get; set; } = new List<Equipment>();
    public IEnumerable<Plant> Plants { get; set; } = new List<Plant>();
    public IEnumerable<Fish> Fishes { get; set; } = new List<Fish>();
    public IEnumerable<Invertebrate> Invertebrates { get; set; } = new List<Invertebrate>();

}
