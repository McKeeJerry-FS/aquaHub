using System;
using AquaHub.Shared.Models.Enums;

namespace AquaHub.Shared.Models;

public class Filter : Equipment
{
    public FilterType Type { get; set; }
    public double FlowRate { get; set; }
    public string Media { get; set; } = string.Empty;
}
