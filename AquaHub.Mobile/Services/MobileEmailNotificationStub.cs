
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquaHub.Shared.Services.Interfaces;

namespace AquaHub.Mobile.Services
{
    public class MobileEmailNotificationStub : IEmailNotificationService
    {
        public Task SendWaterParameterAlertEmailAsync(string userEmail, string userName, string tankName, string parameterName, double value, double? minRange, double? maxRange)
            => Task.CompletedTask;

        public Task SendReminderEmailAsync(string userEmail, string userName, string reminderTitle, string reminderDescription, DateTime dueDate)
            => Task.CompletedTask;

        public Task SendNotificationDigestEmailAsync(string userEmail, string userName, List<string> notifications)
            => Task.CompletedTask;
    }
}
