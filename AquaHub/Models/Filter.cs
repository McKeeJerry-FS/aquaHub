using System;
using AquaHub.Models.Enums;

namespace AquaHub.Models;

public class Filter : Equipment
{
    public FilterType Type { get; set; }
    public double FlowRate { get; set; }
    public string Media { get; set; } = string.Empty;
}
