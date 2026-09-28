using api.Models;
using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDB.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<AppUser>(options), IApplicationDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cast> Cast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<AppUser>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Genre>(b =>
            {
                b.ToTable("Genres");
                b.Property(g => g.Title).IsRequired().HasMaxLength(100);
                b.HasIndex(g => g.Title).IsUnique();
            });

            modelBuilder.Entity<Person>(b =>
            {
                b.ToTable("People");
                b.Property(p => p.ImdbId).HasMaxLength(20);
                b.Property(p => p.FullName).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Movie>(b =>
            {
                b.ToTable("Movies");
                b.OwnsOne(m => m.Info, ConfigureInfo<Movie>);
                b.Navigation(m => m.Info).IsRequired();
                b.HasMany(m => m.Genres).WithMany().UsingEntity(j => j.ToTable("MovieGenres"));
                b.Navigation(m => m.Genres).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Series>(b =>
            {
                b.ToTable("Series");
                b.OwnsOne(s => s.Info, ConfigureInfo<Series>);
                b.Navigation(s => s.Info).IsRequired();
                b.HasMany(s => s.Genres).WithMany().UsingEntity(j => j.ToTable("SeriesGenres"));
                b.Navigation(s => s.Genres).UsePropertyAccessMode(PropertyAccessMode.Field);

                b.HasMany(s => s.Seasons)
                    .WithOne()
                    .HasForeignKey("SeriesId")
                    .OnDelete(DeleteBehavior.Cascade);
                b.Navigation(s => s.Seasons).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Season>(b =>
            {
                b.ToTable("Seasons");

                b.HasMany(s => s.Episodes)
                    .WithOne()
                    .HasForeignKey("SeasonId")
                    .OnDelete(DeleteBehavior.Cascade);
                b.Navigation(s => s.Episodes).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Episode>().ToTable("Episodes");

            modelBuilder.Entity<Comment>(b =>
            {
                b.ToTable("Comments");
                b.HasIndex(c => new { c.TargetType, c.TargetId });
                b.HasIndex(c => c.UserId);
            });

            modelBuilder.Entity<Rate>(b =>
            {
                b.ToTable("Rates");
                b.HasIndex(r => new { r.TargetType, r.TargetId });
                b.HasIndex(r => r.UserId);
            });

            modelBuilder.Entity<Cast>(b =>
            {
                b.ToTable("Cast");
                b.HasIndex(c => new { c.TargetType, c.TargetId });

                b.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey(c => c.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }

        private static void ConfigureInfo<T>(OwnedNavigationBuilder<T, MediaInfo> info) where T : class
        {
            info.Property(i => i.ImdbId).HasColumnName("ImdbId").HasMaxLength(20);
            info.Property(i => i.Title).HasColumnName("Title").IsRequired().HasMaxLength(300);
            info.Property(i => i.Description).HasColumnName("Description");
            info.Property(i => i.PosterUrl).HasColumnName("PosterUrl");
            info.Property(i => i.ReleaseDate).HasColumnName("ReleaseDate");
        }
    }
}
