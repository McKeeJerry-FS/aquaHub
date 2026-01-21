using System;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public class Coral : Livestock
{
    public CoralType CoralType { get; set; }
    public string LightingNeeds { get; set; } = string.Empty;
    public string FlowNeeds { get; set; } = string.Empty;
    public string Placement { get; set; } = string.Empty;
}
