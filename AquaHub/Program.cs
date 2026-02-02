using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AquaHub.Components;
using AquaHub.Components.Account;
using AquaHub.Shared.Data;
using AquaHub.Shared.Models;
using AquaHub.Shared.Services.Interfaces;
using AquaHub.Shared.Services;
using AquaHub.Services;  // Add this line for web-specific services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// Configure Npgsql to handle DateTime as UTC
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Use pooled factory for better performance and thread safety in Blazor Server
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString), poolSize: 128);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<AppUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        // Version3 is .NET 10+ only, use default for .NET 8
        // options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITankService, TankService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<ILivestockService, LivestockService>();
builder.Services.AddScoped<IWaterTestService, WaterTestService>();
builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEmailNotificationService, EmailNotificationService>();
builder.Services.AddScoped<IGrowthRecordService, GrowthRecordService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<ITankHealthService, TankHealthService>();
builder.Services.AddScoped<IPredictiveReminderService, PredictiveReminderService>();
builder.Services.AddScoped<IParameterAlertService, ParameterAlertService>();
builder.Services.AddScoped<JournalService>();
builder.Services.AddHostedService<ReminderBackgroundService>();
builder.Services.AddHostedService<PredictiveReminderBackgroundService>();
builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// createScopeForStatusCodePages is .NET 10+
app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();

app.UseAntiforgery();

// MapStaticAssets is .NET 10+, use UseStaticFiles for .NET 8
app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
