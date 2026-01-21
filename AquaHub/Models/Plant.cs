using System;

namespace AquaHub.Models;

public class Plant : Livestock
{
    public string LightingNeeds { get; set; } = string.Empty;
    public string Co2Needs { get; set; } = string.Empty;
    public string GrowthRate { get; set; } = string.Empty;
}
