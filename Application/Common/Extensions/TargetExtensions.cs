using IMDB.Application.Common.Exceptions;
using IMDB.Domain.Entities;

namespace IMDB.Application.Common.Extensions;
public static class TargetExtensions
{
    public static async Task<bool> MediaExistsAsync(
        this IApplicationDbContext context, Guid mediaId, CancellationToken cancellationToken)
    {
        return await context.Movies.AnyAsync(m => m.Id == mediaId, cancellationToken)
            || await context.Series.AnyAsync(s => s.Id == mediaId, cancellationToken);
    }

    public static async Task<List<Genre>> GetGenresAsync(
        this IApplicationDbContext context, IEnumerable<Guid> genreIds, CancellationToken cancellationToken)
    {
        var ids = genreIds.Distinct().ToList();
        var genres = await context.Genres
            .Where(g => ids.Contains(g.Id))
            .ToListAsync(cancellationToken);

        if (genres.Count != ids.Count)
        {
            var missing = ids.Except(genres.Select(g => g.Id));
            throw new ApplicationsExceptions.NotFoundException(
                $"Genres not found: {string.Join(", ", missing)}");
        }

        return genres;
    }
}
