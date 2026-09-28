using IMDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Common.Interfaces;

// The namespaces IMDB.Application.Series and IMDB.Application.Cast hide these entity names,
// so the aliases are declared inside the namespace, where they win the name lookup.
using Series = IMDB.Domain.Entities.Series;
using Cast = IMDB.Domain.Entities.Cast;

public interface IApplicationDbContext
{
    DbSet<Genre> Genres { get; }
    DbSet<Movie> Movies { get; }
    DbSet<Series> Series { get; }
    DbSet<Person> People { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Rate> Rates { get; }
    DbSet<Cast> Cast { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
