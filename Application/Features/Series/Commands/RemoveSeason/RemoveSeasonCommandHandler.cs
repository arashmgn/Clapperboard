using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.RemoveSeason;
public class RemoveSeasonCommandHandler : IRequestHandler<RemoveSeasonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public RemoveSeasonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveSeasonCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        var season = series.Seasons.FirstOrDefault(s => s.Id == request.SeasonId)
            ?? throw new ApplicationsExceptions.NotFoundException($"Season {request.SeasonId} was not found in series {request.SeriesId}.");

        _context.Episodes.RemoveRange(season.Episodes);
        _context.Seasons.Remove(season);
        series.RemoveSeason(request.SeasonId);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
