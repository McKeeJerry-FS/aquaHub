using System;

namespace AquaHub.Models;

public class Tank
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double VolumeLiters { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
