using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.UpdateEpisode;
public class UpdateEpisodeCommandHandler : IRequestHandler<UpdateEpisodeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEpisodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEpisodeCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        series.UpdateEpisode(
            request.SeasonId, request.EpisodeId, request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, request.EpisodeNumber, request.DurationMinutes);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
