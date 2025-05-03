using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task SetupDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        await EnsureDatabaseAsync(dbContext);
        await RunMigrationsAsync(dbContext);
        await SeedDatabaseAsync(dbContext);
    }

    private static async Task EnsureDatabaseAsync(ApplicationDBContext dbContext)
    {
        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync())
                await dbCreator.CreateAsync();
        });
    }

    private static async Task RunMigrationsAsync(ApplicationDBContext dbContext)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await dbContext.Database.MigrateAsync();
        });
    }

    private static async Task SeedDatabaseAsync(ApplicationDBContext dbContext)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Avoid duplicating seed data
            if (dbContext.Posts is not null && await dbContext.Posts.AnyAsync() is false)
            {
                dbContext.Posts.AddRange(new List<Post>
                {
                    new() {Content = "Hello World!" },
                    new() {Content = "This is a seeded post." }
                });

                await dbContext.SaveChangesAsync();
            }
        });
    }
}