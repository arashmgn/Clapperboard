using api.Enums;
using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Series.Commands.DeleteSeries;

public class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.Series
            .Include(s => s.Seasons)
                .ThenInclude(se => se.Episodes)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (series is null)
            return false;

        // Seasons and episodes go with the series (cascade), but comments, rates and cast of the episodes must be removed by hand too.
        var episodeIds = series.Seasons.SelectMany(se => se.Episodes).Select(e => e.Id).ToList();

        await _context.RemoveTargetDependentsAsync(ReviewTargetType.Series, new[] { series.Id }, cancellationToken);
        await _context.RemoveTargetDependentsAsync(ReviewTargetType.Episode, episodeIds, cancellationToken);
        _context.Series.Remove(series);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
