namespace AquaHub.Services.Interfaces;

public interface IEmailNotificationService
{
    Task SendReminderEmailAsync(string userEmail, string userName, string reminderTitle, string reminderDescription, DateTime dueDate);
    Task SendWaterParameterAlertEmailAsync(string userEmail, string userName, string tankName, string parameterName, double value, double? minRange, double? maxRange);
    Task SendNotificationDigestEmailAsync(string userEmail, string userName, List<string> notifications);
}
