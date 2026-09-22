using api.Models;
using IMDB.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Infrastructure.Persistence
{
    internal class ApplicationDbContext
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

            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Person>().ToTable("People");

            modelBuilder.Entity<Movie>(b =>
            {
                b.ToTable("Movies");
                b.OwnsOne(m => m.Info, ConfigureInfo<Movie>);
                b.Navigation(m => m.Info).IsRequired();
                b.HasMany(m => m.Genres).WithMany().UsingEntity(j => j.ToTable("MovieGenres"));
                b.Navigation(m => m.Genres).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

        }
}
