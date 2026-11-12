using IMDB.Application.Common.Abstractions;
using IMDB.Domain.Entities;
using IMDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<AppUser>(options), IApplicationDbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Series> Series => Set<Series>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<Episode> Episodes => Set<Episode>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Cast> Casts => Set<Cast>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Rate> Rates => Set<Rate>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
    }
}
