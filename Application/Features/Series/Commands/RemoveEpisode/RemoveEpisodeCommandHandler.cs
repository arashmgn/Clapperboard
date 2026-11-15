using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.RemoveEpisode;
public class RemoveEpisodeCommandHandler : IRequestHandler<RemoveEpisodeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public RemoveEpisodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveEpisodeCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        var episode = series.Seasons
            .FirstOrDefault(s => s.Id == request.SeasonId)?.Episodes
            .FirstOrDefault(e => e.Id == request.EpisodeId)
            ?? throw new ApplicationsExceptions.NotFoundException($"Episode {request.EpisodeId} was not found in season {request.SeasonId}.");

        _context.Episodes.Remove(episode);
        series.RemoveEpisode(request.SeasonId, request.EpisodeId);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
