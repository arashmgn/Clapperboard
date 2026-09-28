using api.Enums;
using IMDB.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Common.Extensions;

public static class ReviewTargetExtensions
{
    // Comment, Rate and Cast point at their target by TargetType + TargetId with no foreign key,
    // so existence has to be checked by hand.
    public static Task<bool> TargetExistsAsync(this IApplicationDbContext context,
        ReviewTargetType targetType, int targetId, CancellationToken cancellationToken)
    {
        return targetType switch
        {
            ReviewTargetType.Movie => context.Movies.AnyAsync(m => m.Id == targetId, cancellationToken),
            ReviewTargetType.Series => context.Series.AnyAsync(s => s.Id == targetId, cancellationToken),
            ReviewTargetType.Episode => context.Series.AnyAsync(
                s => s.Seasons.Any(se => se.Episodes.Any(e => e.Id == targetId)), cancellationToken),
            _ => Task.FromResult(false)
        };
    }

    // No foreign key also means no database cascade, so the comments, rates and cast of a deleted
    // target are removed here, in the same SaveChanges as the target itself.
    public static async Task RemoveTargetReviewsAsync(this IApplicationDbContext context,
        ReviewTargetType targetType, IReadOnlyCollection<int> targetIds, CancellationToken cancellationToken)
    {
        if (targetIds.Count == 0)
            return;

        var comments = await context.Comments
            .Where(c => c.TargetType == targetType && targetIds.Contains(c.TargetId))
            .ToListAsync(cancellationToken);
        context.Comments.RemoveRange(comments);

        var rates = await context.Rates
            .Where(r => r.TargetType == targetType && targetIds.Contains(r.TargetId))
            .ToListAsync(cancellationToken);
        context.Rates.RemoveRange(rates);

        var cast = await context.Cast
            .Where(c => c.TargetType == targetType && targetIds.Contains(c.TargetId))
            .ToListAsync(cancellationToken);
        context.Cast.RemoveRange(cast);
    }
}
