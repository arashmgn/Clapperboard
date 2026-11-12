using IMDB.Domain.Entities;
using Cast = IMDB.Domain.Entities.Cast;
using Series = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Common.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    DbSet<Series> Series { get; }
    DbSet<Season> Seasons { get; }
    DbSet<Episode> Episodes { get; }
    DbSet<Person> People { get; }
    DbSet<Cast> Casts { get; }
    DbSet<Genre> Genres { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Rate> Rates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}