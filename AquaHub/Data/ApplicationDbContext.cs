using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AquaHub.Models;

namespace AquaHub.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{

    public DbSet<Tank> Tanks { get; set; }
    public DbSet<Livestock> Livestock { get; set; }
    public DbSet<Coral> Corals { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Filter> Filters { get; set; }
    public DbSet<Light> Lights { get; set; }
    public DbSet<ProteinSkimmer> ProteinSkimmers { get; set; }
    public DbSet<WaterTest> WaterTests { get; set; }
    public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
    public DbSet<DosingRecord> DosingRecords { get; set; }
    public DbSet<PhotoLog> PhotoLogs { get; set; }

}