using IMDB.Application.Common.Exceptions;
using IMDB.Domain.Entities;

namespace IMDB.Application.Common.Extensions;
public static class SeriesExtensions
{
    public static async Task<Series> GetSeriesWithSeasonsAsync(
        this IApplicationDbContext context, Guid seriesId, CancellationToken cancellationToken)
    {
        return await context.Series
            .Include(s => s.Seasons)
            .ThenInclude(s => s.Episodes)
            .FirstOrDefaultAsync(s => s.Id == seriesId, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Series {seriesId} was not found.");
    }
}
