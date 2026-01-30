using Microsoft.Extensions.Logging;
using AquaHub.Shared.Services;
using AquaHub.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AquaHub.Shared.Data;
using Microsoft.AspNetCore.Components.Authorization;
using AquaHub.Mobile.Services;

namespace AquaHub.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

		// Add authentication
		builder.Services.AddAuthorizationCore();
		builder.Services.AddScoped<AuthenticationStateProvider, MobileAuthenticationStateProvider>();

		// Add SQLite database for mobile (local storage)
		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "aquahub.db");
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlite($"Data Source={dbPath}"));

		// Register shared services
		builder.Services.AddScoped<ITankService, TankService>();
		builder.Services.AddScoped<IEquipmentService, EquipmentService>();
		builder.Services.AddScoped<ILivestockService, LivestockService>();
		builder.Services.AddScoped<IWaterTestService, WaterTestService>();
		builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();
		builder.Services.AddScoped<IReminderService, ReminderService>();
		builder.Services.AddScoped<INotificationService, NotificationService>();
		builder.Services.AddScoped<ITankHealthService, TankHealthService>();
		builder.Services.AddScoped<IExpenseService, ExpenseService>();
		builder.Services.AddScoped<IGrowthRecordService, GrowthRecordService>();
		builder.Services.AddScoped<IParameterAlertService, ParameterAlertService>();
		builder.Services.AddScoped<IPredictiveReminderService, PredictiveReminderService>();

		// TODO: Add mobile-specific file upload service
		// builder.Services.AddScoped<IFileUploadService, MobileFileUploadService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
