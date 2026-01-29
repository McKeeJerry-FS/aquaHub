namespace AquaHub.Models.Enums;

/// <summary>
/// Water parameters that can be monitored for alerts
/// </summary>
public enum WaterParameter
{
    PH,
    Temperature,
    Ammonia,
    Nitrite,
    Nitrate,
    GH,          // General Hardness (Freshwater)
    KH,          // Carbonate Hardness (Freshwater)
    TDS,         // Total Dissolved Solids (Freshwater)
    Salinity,    // Saltwater/Reef
    Alkalinity,  // Reef
    Calcium,     // Reef
    Magnesium,   // Reef
    Phosphate    // Reef
}
