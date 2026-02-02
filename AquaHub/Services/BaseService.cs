using AquaHub.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AquaHub.Shared.Services;

public abstract class BaseService
{
    protected readonly IDbContextFactory<ApplicationDbContext> ContextFactory;

    protected BaseService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        ContextFactory = contextFactory;
    }

    protected async Task<ApplicationDbContext> CreateContextAsync()
    {
        return await ContextFactory.CreateDbContextAsync();
    }
}
