using AquaHub.Shared.Data;
using AquaHub.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Services;

public class JournalService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public JournalService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    // Get all journal entries for a specific tank
    public async Task<List<JournalEntry>> GetJournalEntriesForTankAsync(int tankId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.JournalEntries
            .Where(j => j.TankId == tankId)
            .Include(j => j.MaintenanceLinks)
                .ThenInclude(ml => ml.MaintenanceLog)
            .Include(j => j.WaterTestLinks)
                .ThenInclude(wl => wl.WaterTest)
            .OrderByDescending(j => j.Timestamp)
            .ToListAsync();
    }

    // Get a specific journal entry with all linked records
    public async Task<JournalEntry?> GetJournalEntryByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.JournalEntries
            .Include(j => j.Tank)
            .Include(j => j.MaintenanceLinks)
                .ThenInclude(ml => ml.MaintenanceLog)
            .Include(j => j.WaterTestLinks)
                .ThenInclude(wl => wl.WaterTest)
            .FirstOrDefaultAsync(j => j.Id == id);
    }

    // Create a new journal entry
    public async Task<JournalEntry> CreateJournalEntryAsync(JournalEntry journalEntry)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        journalEntry.Timestamp = DateTime.UtcNow;
        context.JournalEntries.Add(journalEntry);
        await context.SaveChangesAsync();
        return journalEntry;
    }

    // Update an existing journal entry
    public async Task<bool> UpdateJournalEntryAsync(JournalEntry journalEntry)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        context.JournalEntries.Update(journalEntry);
        return await context.SaveChangesAsync() > 0;
    }

    // Delete a journal entry
    public async Task<bool> DeleteJournalEntryAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entry = await context.JournalEntries.FindAsync(id);
        if (entry == null) return false;

        context.JournalEntries.Remove(entry);
        return await context.SaveChangesAsync() > 0;
    }

    // Link maintenance log to journal entry
    public async Task<bool> LinkMaintenanceLogAsync(int journalEntryId, int maintenanceLogId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        // Check if link already exists
        var existingLink = await context.JournalMaintenanceLinks
            .FirstOrDefaultAsync(jml => jml.JournalEntryId == journalEntryId && jml.MaintenanceLogId == maintenanceLogId);

        if (existingLink != null) return false;

        var link = new JournalMaintenanceLink
        {
            JournalEntryId = journalEntryId,
            MaintenanceLogId = maintenanceLogId
        };

        context.JournalMaintenanceLinks.Add(link);
        return await context.SaveChangesAsync() > 0;
    }

    // Unlink maintenance log from journal entry
    public async Task<bool> UnlinkMaintenanceLogAsync(int journalEntryId, int maintenanceLogId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var link = await context.JournalMaintenanceLinks
            .FirstOrDefaultAsync(jml => jml.JournalEntryId == journalEntryId && jml.MaintenanceLogId == maintenanceLogId);

        if (link == null) return false;

        context.JournalMaintenanceLinks.Remove(link);
        return await context.SaveChangesAsync() > 0;
    }

    // Link water test to journal entry
    public async Task<bool> LinkWaterTestAsync(int journalEntryId, int waterTestId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        // Check if link already exists
        var existingLink = await context.JournalWaterTestLinks
            .FirstOrDefaultAsync(jwt => jwt.JournalEntryId == journalEntryId && jwt.WaterTestId == waterTestId);

        if (existingLink != null) return false;

        var link = new JournalWaterTestLink
        {
            JournalEntryId = journalEntryId,
            WaterTestId = waterTestId
        };

        context.JournalWaterTestLinks.Add(link);
        return await context.SaveChangesAsync() > 0;
    }

    // Unlink water test from journal entry
    public async Task<bool> UnlinkWaterTestAsync(int journalEntryId, int waterTestId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var link = await context.JournalWaterTestLinks
            .FirstOrDefaultAsync(jwt => jwt.JournalEntryId == journalEntryId && jwt.WaterTestId == waterTestId);

        if (link == null) return false;

        context.JournalWaterTestLinks.Remove(link);
        return await context.SaveChangesAsync() > 0;
    }

    // Get available maintenance logs for a tank (not yet linked to a specific journal entry)
    public async Task<List<MaintenanceLog>> GetAvailableMaintenanceLogsAsync(int tankId, int? excludeJournalEntryId = null)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var query = context.MaintenanceLogs
            .Where(ml => ml.TankId == tankId);

        if (excludeJournalEntryId.HasValue)
        {
            var linkedIds = await context.JournalMaintenanceLinks
                .Where(jml => jml.JournalEntryId == excludeJournalEntryId.Value)
                .Select(jml => jml.MaintenanceLogId)
                .ToListAsync();

            query = query.Where(ml => !linkedIds.Contains(ml.Id));
        }

        return await query
            .OrderByDescending(ml => ml.Timestamp)
            .Take(20) // Limit to recent 20 for dropdown
            .ToListAsync();
    }

    // Get available water tests for a tank (not yet linked to a specific journal entry)
    public async Task<List<WaterTest>> GetAvailableWaterTestsAsync(int tankId, int? excludeJournalEntryId = null)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var query = context.WaterTests
            .Where(wt => wt.TankId == tankId);

        if (excludeJournalEntryId.HasValue)
        {
            var linkedIds = await context.JournalWaterTestLinks
                .Where(jwt => jwt.JournalEntryId == excludeJournalEntryId.Value)
                .Select(jwt => jwt.WaterTestId)
                .ToListAsync();

            query = query.Where(wt => !linkedIds.Contains(wt.Id));
        }

        return await query
            .OrderByDescending(wt => wt.Timestamp)
            .Take(20) // Limit to recent 20 for dropdown
            .ToListAsync();
    }
}
