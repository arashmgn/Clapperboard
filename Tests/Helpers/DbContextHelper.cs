using IMDB.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tests.Helpers;

public static class DbContextHelper
{
    public static ApplicationDbContext CreateInMemory(string? name = null)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(name ?? Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }
}
