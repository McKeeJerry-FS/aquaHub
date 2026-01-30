using AquaHub.Shared.Data;
using AquaHub.Shared.Models;
using AquaHub.Shared.Models.Enums;

namespace AquaHub.Mobile.Services;

public static class DatabaseSeeder
{
    public static async Task SeedDataAsync(ApplicationDbContext context, string userId)
    {
        // Check if user already has data
        if (context.Tanks.Any(t => t.UserId == userId))
        {
            return; // Already seeded
        }

        // Create sample tanks
        var tank1 = new Tank
        {
            UserId = userId,
            Name = "Living Room Reef",
            VolumeGallons = 75,
            Type = AquariumType.Reef,
            StartDate = DateTime.UtcNow.AddMonths(-6),
            Notes = "Main display tank"
        };

        var tank2 = new Tank
        {
            UserId = userId,
            Name = "Office Planted Tank",
            VolumeGallons = 20,
            Type = AquariumType.Planted,
            StartDate = DateTime.UtcNow.AddMonths(-3),
            Notes = "Low-tech planted aquarium"
        };

        context.Tanks.AddRange(tank1, tank2);
        await context.SaveChangesAsync();

        // Add sample equipment
        var filter = new Filter
        {
            TankId = tank1.Id,
            Brand = "Fluval",
            Model = "FX6",
            InstalledOn = tank1.StartDate,
            Type = FilterType.Canister,
            FlowRate = 925
        };

        var light = new Light
        {
            TankId = tank1.Id,
            Brand = "Kessil",
            Model = "A360X",
            InstalledOn = tank1.StartDate,
            Wattage = 90,
            IsDimmable = true,
            IntensityPercent = 75
        };

        var heater = new Heater
        {
            TankId = tank1.Id,
            Brand = "Eheim",
            Model = "Jager 150W",
            InstalledOn = tank1.StartDate,
            MinTemperature = 76,
            MaxTemperature = 78
        };

        context.Filters.Add(filter);
        context.Lights.Add(light);
        context.Heaters.Add(heater);
        await context.SaveChangesAsync();

        // Add sample livestock
        var clownfish = new SaltwaterFish
        {
            TankId = tank1.Id,
            Name = "Nemo",
            Species = "Amphiprion ocellaris",
            AddedOn = tank1.StartDate.AddDays(30),
            Notes = "Ocellaris Clownfish"
        };

        var coral = new Coral
        {
            TankId = tank1.Id,
            Name = "Green Star Polyps",
            Species = "Pachyclavularia",
            AddedOn = tank1.StartDate.AddDays(45),
            CoralType = CoralType.Soft_GSP,
            Notes = "Fast growing"
        };

        context.SaltwaterFish.Add(clownfish);
        context.Corals.Add(coral);
        await context.SaveChangesAsync();
    }
}