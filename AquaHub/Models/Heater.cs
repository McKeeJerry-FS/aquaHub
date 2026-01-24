using System;

namespace AquaHub.Models;

public class Heater : Equipment
{
    public decimal MinTemperature { get; set; }
    public decimal MaxTemperature { get; set; }
}
