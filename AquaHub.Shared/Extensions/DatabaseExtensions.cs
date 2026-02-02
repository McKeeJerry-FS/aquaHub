using Microsoft.EntityFrameworkCore;
using AquaHub.Shared.Data;

namespace AquaHub.Shared.Extensions;

public static class DatabaseExtensions
{
    public static async Task EnsureJournalTablesExistAsync(this ApplicationDbContext context)
    {
        // Create JournalEntries table if it doesn't exist
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE TABLE IF NOT EXISTS ""JournalEntries"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""TankId"" INTEGER NOT NULL,
                ""Title"" VARCHAR(200) NOT NULL,
                ""Content"" VARCHAR(5000) NOT NULL,
                ""Timestamp"" TIMESTAMP WITH TIME ZONE NOT NULL,
                ""ImagePath"" TEXT NULL,
                CONSTRAINT ""FK_JournalEntries_Tanks_TankId"" FOREIGN KEY (""TankId"") 
                    REFERENCES ""Tanks"" (""Id"") ON DELETE CASCADE
            );
        ");

        // Create JournalMaintenanceLinks table if it doesn't exist
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE TABLE IF NOT EXISTS ""JournalMaintenanceLinks"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""JournalEntryId"" INTEGER NOT NULL,
                ""MaintenanceLogId"" INTEGER NOT NULL,
                CONSTRAINT ""FK_JournalMaintenanceLinks_JournalEntries_JournalEntryId"" FOREIGN KEY (""JournalEntryId"") 
                    REFERENCES ""JournalEntries"" (""Id"") ON DELETE CASCADE,
                CONSTRAINT ""FK_JournalMaintenanceLinks_MaintenanceLogs_MaintenanceLogId"" FOREIGN KEY (""MaintenanceLogId"") 
                    REFERENCES ""MaintenanceLogs"" (""Id"") ON DELETE CASCADE
            );
        ");

        // Create JournalWaterTestLinks table if it doesn't exist
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE TABLE IF NOT EXISTS ""JournalWaterTestLinks"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""JournalEntryId"" INTEGER NOT NULL,
                ""WaterTestId"" INTEGER NOT NULL,
                CONSTRAINT ""FK_JournalWaterTestLinks_JournalEntries_JournalEntryId"" FOREIGN KEY (""JournalEntryId"") 
                    REFERENCES ""JournalEntries"" (""Id"") ON DELETE CASCADE,
                CONSTRAINT ""FK_JournalWaterTestLinks_WaterTests_WaterTestId"" FOREIGN KEY (""WaterTestId"") 
                    REFERENCES ""WaterTests"" (""Id"") ON DELETE CASCADE
            );
        ");

        // Create indexes
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE INDEX IF NOT EXISTS ""IX_JournalEntries_TankId"" ON ""JournalEntries"" (""TankId"");
            CREATE INDEX IF NOT EXISTS ""IX_JournalMaintenanceLinks_JournalEntryId"" ON ""JournalMaintenanceLinks"" (""JournalEntryId"");
            CREATE INDEX IF NOT EXISTS ""IX_JournalMaintenanceLinks_MaintenanceLogId"" ON ""JournalMaintenanceLinks"" (""MaintenanceLogId"");
            CREATE INDEX IF NOT EXISTS ""IX_JournalWaterTestLinks_JournalEntryId"" ON ""JournalWaterTestLinks"" (""JournalEntryId"");
            CREATE INDEX IF NOT EXISTS ""IX_JournalWaterTestLinks_WaterTestId"" ON ""JournalWaterTestLinks"" (""WaterTestId"");
        ");
    }
}
