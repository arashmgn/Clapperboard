using IMDB.Infrastructure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IMDB.Infrastructure.Persistence;

public static class DatabaseInitializer
{
    private const int MaxAttempts = 15;

    public static async Task InitializeAsync(IServiceProvider services, IConfiguration configuration)
    {
        if (!configuration.GetValue("Database:MigrateOnStartup", true))
            return;

        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(DatabaseInitializer));
        var context = services.GetRequiredService<ApplicationDbContext>();

        for (var attempt = 1; ; attempt++)
        {
            try
            {
                await context.Database.MigrateAsync();
                break;
            }
            catch (SqlException ex) when (attempt < MaxAttempts)
            {
                logger.LogWarning("Database is not ready yet (attempt {Attempt}/{Max}): {Message}", attempt, MaxAttempts, ex.Message);
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }

        await IdentitySeeder.SeedAsync(services, configuration);
    }
}
