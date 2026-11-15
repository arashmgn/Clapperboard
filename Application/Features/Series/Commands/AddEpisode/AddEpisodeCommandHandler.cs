using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.AddEpisode;
public class AddEpisodeCommandHandler : IRequestHandler<AddEpisodeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddEpisodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(AddEpisodeCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        var episode = series.AddEpisode(
            request.SeasonId, request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, request.EpisodeNumber, request.DurationMinutes);
        await _context.SaveChangesAsync(cancellationToken);

        return episode.Id;
    }
}
