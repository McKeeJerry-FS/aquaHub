using AquaHub.Shared.Services.Interfaces;

namespace AquaHub.Services;

public class EmailNotificationService : IEmailNotificationService
{
    // For now, this is a placeholder implementation
    // You can integrate with SendGrid, SMTP, or other email services later
    private readonly ILogger<EmailNotificationService> _logger;

    public EmailNotificationService(ILogger<EmailNotificationService> logger)
    {
        _logger = logger;
    }

    public async Task SendReminderEmailAsync(string userEmail, string userName, string reminderTitle, string reminderDescription, DateTime dueDate)
    {
        // TODO: Implement actual email sending
        // For now, just log it
        _logger.LogInformation(
            "Email would be sent to {Email}: Reminder '{Title}' is due on {DueDate}",
            userEmail,
            reminderTitle,
            dueDate
        );

        await Task.CompletedTask;

        // Example implementation with SendGrid (commented out):
        /*
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("noreply@aquahub.com", "AquaHub");
        var to = new EmailAddress(userEmail, userName);
        var subject = $"Reminder: {reminderTitle}";
        var plainTextContent = $"Hello {userName},\n\n" +
                               $"This is a reminder that '{reminderTitle}' is due on {dueDate:MMM dd, yyyy 'at' h:mm tt}.\n\n" +
                               $"{reminderDescription}\n\n" +
                               $"Best regards,\nAquaHub Team";
        var htmlContent = $"<p>Hello {userName},</p>" +
                         $"<p>This is a reminder that <strong>{reminderTitle}</strong> is due on {dueDate:MMM dd, yyyy 'at' h:mm tt}.</p>" +
                         $"<p>{reminderDescription}</p>" +
                         $"<p>Best regards,<br>AquaHub Team</p>";
        
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        await client.SendEmailAsync(msg);
        */
    }

    public async Task SendWaterParameterAlertEmailAsync(string userEmail, string userName, string tankName, string parameterName, double value, double? minRange, double? maxRange)
    {
        var rangeText = "";
        if (minRange.HasValue && maxRange.HasValue)
            rangeText = $" (Expected range: {minRange.Value} - {maxRange.Value})";
        else if (minRange.HasValue)
            rangeText = $" (Minimum: {minRange.Value})";
        else if (maxRange.HasValue)
            rangeText = $" (Maximum: {maxRange.Value})";

        _logger.LogInformation(
            "Email would be sent to {Email}: Water parameter alert for {Tank} - {Parameter}: {Value}{Range}",
            userEmail,
            tankName,
            parameterName,
            value,
            rangeText
        );

        await Task.CompletedTask;
    }

    public async Task SendNotificationDigestEmailAsync(string userEmail, string userName, List<string> notifications)
    {
        _logger.LogInformation(
            "Digest email would be sent to {Email} with {Count} notifications",
            userEmail,
            notifications.Count
        );

        await Task.CompletedTask;
    }
}
