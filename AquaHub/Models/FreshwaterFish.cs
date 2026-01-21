using System;

namespace AquaHub.Models;

public class FreshwaterFish : Livestock
{
    public string Diet { get; set; } = string.Empty;
    public double MinTankSize { get; set; }
}
