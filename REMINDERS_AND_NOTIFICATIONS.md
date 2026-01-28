# Reminders and Notifications System - AquaHub

## Overview

The Reminders and Notifications system helps users stay on top of their aquarium maintenance and alerts them when water parameters are out of optimal ranges.

## Features

### 1. Reminders

- **Create custom reminders** for various tasks:
  - Maintenance
  - Feeding
  - Water Tests
  - Water Changes
  - Equipment Checks
  - Medication
  - Cleaning
  - Other tasks

- **Flexible scheduling** with multiple frequency options:
  - Once (one-time reminders)
  - Daily
  - Weekly
  - Bi-weekly
  - Monthly
  - Quarterly
  - Yearly

- **Tank-specific or general reminders** - Associate reminders with specific tanks or keep them general
- **Customizable notifications** - Set how many hours before the due date you want to be notified
- **Email notifications** - Option to receive email notifications for each reminder
- **Auto-rescheduling** - Recurring reminders automatically calculate the next due date when marked complete
- **Overdue tracking** - See which reminders are past due

### 2. Notifications

- **In-app notifications** - Always receive notifications within the application
- **Notification types**:
  - Reminder notifications (upcoming tasks)
  - Water parameter alerts (when parameters are out of range)
  - Equipment alerts (for future expansion)
  - General notifications

- **Unread badge** - Visual indicator of unread notifications count
- **Filter options** - View all notifications or only unread ones
- **Mark as read** - Individual or bulk mark as read
- **Auto-delete** - Users can delete notifications they no longer need

### 3. Water Parameter Monitoring

The system automatically checks water test results and creates alerts when parameters are outside optimal ranges:

**Freshwater Tanks:**

- pH: 6.5 - 8.0
- Ammonia: < 0.25 ppm
- Nitrite: < 0.5 ppm
- Nitrate: < 40 ppm
- Temperature: 72°F - 82°F
- Phosphate: < 1.0 ppm

**Saltwater/Reef Tanks:**

- pH: 8.0 - 8.4
- Ammonia: < 0.25 ppm
- Nitrite: < 0.5 ppm
- Nitrate: < 20 ppm
- Temperature: 75°F - 80°F
- Salinity: 1.023 - 1.026
- Phosphate: < 0.03 ppm

**Reef Tanks (additional):**

- Calcium: 380 - 450 ppm
- Magnesium: 1250 - 1350 ppm

### 4. Email Notifications

Users can configure email notification preferences:

- **Enable/disable email notifications** globally
- **Choose delivery mode**:
  - Instant (emails sent immediately)
  - Daily digest (once per day)
  - Weekly digest (once per week)
- **Control notification types**:
  - Reminder notifications
  - Water parameter alerts
  - Equipment alerts

### 5. Background Service

- **Automated checking** - Background service runs every hour to check for reminders that need notifications
- **Smart notification generation** - Prevents duplicate notifications
- **No manual intervention** - Runs automatically as long as the application is running

## How to Use

### Creating a Reminder

1. Navigate to **Reminders** page from the navigation menu
2. Click **Add Reminder** button
3. Fill in the reminder details:
   - Title (required)
   - Description (optional)
   - Type (select from dropdown)
   - Tank (optional - select a specific tank or leave blank for all tanks)
   - Frequency (how often the task repeats)
   - Next Due Date
   - Notification timing (hours before due date)
   - Email notification preference
   - Active status
4. Click **Save**

### Completing a Reminder

1. Go to the **Reminders** page
2. Find the reminder you want to mark complete
3. Click the **Complete** button
4. The reminder will be automatically rescheduled based on its frequency
   - One-time reminders will be marked as inactive

### Viewing Notifications

1. Click **Notifications** in the navigation menu
2. See the unread count badge on the bell icon
3. Filter between All and Unread notifications
4. Click on a notification to mark it as read
5. Delete notifications you no longer need

### Configuring Notification Settings

1. Navigate to **Notifications** page
2. Click **Settings** button
3. Configure your preferences:
   - Enable/disable email notifications
   - Choose email delivery mode
   - Enable/disable specific notification types
4. Click **Save Settings**

## Technical Implementation

### Models

- `Reminder` - Stores reminder information
- `Notification` - Stores notification records
- `UserNotificationSettings` - User preferences for notifications
- `ReminderType` - Enum for reminder categories
- `ReminderFrequency` - Enum for scheduling options
- `NotificationType` - Enum for notification categories

### Services

- `ReminderService` - Manages reminder CRUD operations and scheduling
- `NotificationService` - Handles notification creation and management
- `EmailNotificationService` - Sends email notifications (placeholder for now)
- `ReminderBackgroundService` - Hourly background task to check reminders

### Pages

- `/reminders` - Manage reminders
- `/notifications` - View notifications
- `/notification-settings` - Configure notification preferences

### Database

All data is stored in PostgreSQL with proper relationships:

- Reminders linked to users and optionally to tanks
- Notifications linked to users, tanks, reminders, and water tests
- User settings linked to users

## Future Enhancements

- Integration with SendGrid or other email services for actual email sending
- Push notifications for mobile devices
- SMS notifications
- Notification sound preferences
- Snooze functionality for reminders
- Reminder templates for common tasks
- Analytics and trends for water parameters
- Equipment maintenance tracking with automated reminders
- Integration with smart aquarium devices

## Notes

- The email service is currently a placeholder that logs to the console. To implement actual email sending, integrate with SendGrid, SMTP, or another email service provider.
- The background service checks every hour. You can adjust the interval in `ReminderBackgroundService.cs`.
- Water parameter ranges are hardcoded but can be made configurable per tank in future updates.
