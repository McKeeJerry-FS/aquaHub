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
			{
				options.UseSqlite($"Data Source={dbPath}");
				// Disable foreign key constraints for mobile
				options.UseSqlite($"Data Source={dbPath};Foreign Keys=False");
			});

		// Mobile file upload stub (not needed for initial implementation)
		builder.Services.AddScoped<IFileUploadService>(sp => new MobileFileUploadStub());

		// Register shared services
		builder.Services.AddScoped<ITankService, TankService>();
		//builder.Services.AddScoped<IFileUploadService, FileUploadService>();
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

		// Register secure storage for account management
		builder.Services.AddSingleton<AquaHub.Mobile.Services.ISecureStorage, MauiSecureStorage>();

		// Register mobile alert service
		builder.Services.AddScoped<IMobileAlertService, MobileAlertService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		// Clear any previous error messages
		StartupErrorHolder.ErrorMessage = null;

		// Initialize database in background - don't block app startup
		_ = Task.Run(async () =>
		{
			await Task.Delay(100); // Let app start first

			using var scope = app.Services.CreateScope();
			try
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

				Console.WriteLine("=== STARTING DATABASE INIT ===");

				// For development: delete and recreate database to pick up schema changes
				dbContext.Database.EnsureDeleted();
				Console.WriteLine("Database deleted");

				dbContext.Database.EnsureCreated();
				Console.WriteLine("Database created");

				// Seed sample data for mobile user
				await DatabaseSeeder.SeedDataAsync(dbContext, "mobile-user-1");
				Console.WriteLine("Sample data seeded successfully");

				// Clear error message on success
				StartupErrorHolder.ErrorMessage = null;
			}
			catch (Exception ex)
			{
				var errorMsg = $"{ex.GetType().Name}: {ex.Message}\n\n";
				if (ex.InnerException != null)
				{
					errorMsg += $"Inner: {ex.InnerException.Message}\n\n";
				}
				errorMsg += $"Stack:\n{ex.StackTrace}";

				StartupErrorHolder.ErrorMessage = errorMsg;
				Console.WriteLine($"=== DATABASE ERROR ===\n{errorMsg}");
			}
		});

		return app;
	}
}

public static class StartupErrorHolder
{
	public static string? ErrorMessage { get; set; }
}

// Temporary stub for IFileUploadService - mobile file handling to be implemented later
public class MobileFileUploadStub : IFileUploadService
{
	public Task<string?> SaveImageAsync(Stream fileStream, string fileName)
	{
		// TODO: Implement mobile file storage using MAUI MediaPicker
		return Task.FromResult<string?>(null);
	}

	public Task<bool> DeleteImageAsync(string imagePath)
	{
		// TODO: Implement mobile file deletion
		return Task.FromResult(true);
	}
}
