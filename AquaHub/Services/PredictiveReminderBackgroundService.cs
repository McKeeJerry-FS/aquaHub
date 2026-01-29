using AquaHub.Data;
using AquaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

/// <summary>
/// Background service that periodically generates predictive reminders for all users
/// </summary>
public class PredictiveReminderBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PredictiveReminderBackgroundService> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromHours(6); // Run every 6 hours

    public PredictiveReminderBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<PredictiveReminderBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Predictive Reminder Background Service started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await GeneratePredictionsForAllUsersAsync();
                await CleanupOldPredictionsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating predictive reminders");
            }

            // Wait for the next interval
            await Task.Delay(_interval, stoppingToken);
        }

        _logger.LogInformation("Predictive Reminder Background Service stopped");
    }

    private async Task GeneratePredictionsForAllUsersAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var predictiveReminderService = scope.ServiceProvider.GetRequiredService<IPredictiveReminderService>();

        // Get all active users who have tanks
        var userIds = await context.Tanks
            .Select(t => t.UserId)
            .Distinct()
            .ToListAsync();

        _logger.LogInformation("Generating predictions for {UserCount} users", userIds.Count);

        foreach (var userId in userIds)
        {
            try
            {
                // Check if user already has recent predictions (within last 24 hours)
                var recentPredictions = await context.PredictiveReminders
                    .Where(pr => pr.UserId == userId &&
                                pr.GeneratedAt >= DateTime.UtcNow.AddHours(-24) &&
                                !pr.IsAccepted &&
                                !pr.IsDismissed)
                    .AnyAsync();

                if (!recentPredictions)
                {
                    await predictiveReminderService.GeneratePredictionsAsync(userId);
                    _logger.LogInformation("Generated predictions for user {UserId}", userId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating predictions for user {UserId}", userId);
            }

            // Small delay to avoid overwhelming the database
            await Task.Delay(100);
        }
    }

    private async Task CleanupOldPredictionsAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var predictiveReminderService = scope.ServiceProvider.GetRequiredService<IPredictiveReminderService>();

        try
        {
            await predictiveReminderService.CleanupOldPredictionsAsync();
            _logger.LogInformation("Cleaned up old predictions");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cleaning up old predictions");
        }
    }
}
