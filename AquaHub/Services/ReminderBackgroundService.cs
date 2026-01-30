using AquaHub.Shared.Services.Interfaces;

namespace AquaHub.Services;

public class ReminderBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ReminderBackgroundService> _logger;
    private readonly TimeSpan _checkInterval = TimeSpan.FromHours(1); // Check every hour

    public ReminderBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<ReminderBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Reminder Background Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await CheckRemindersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred checking reminders.");
            }

            // Wait for the next check interval
            await Task.Delay(_checkInterval, stoppingToken);
        }

        _logger.LogInformation("Reminder Background Service is stopping.");
    }

    private async Task CheckRemindersAsync()
    {
        _logger.LogInformation("Checking reminders at {Time}", DateTime.UtcNow);

        using var scope = _serviceProvider.CreateScope();
        var reminderService = scope.ServiceProvider.GetRequiredService<IReminderService>();

        var reminders = await reminderService.CheckAndGenerateNotificationsAsync();

        if (reminders.Any())
        {
            _logger.LogInformation(
                "Generated notifications for {Count} reminders",
                reminders.Count
            );
        }
    }
}
