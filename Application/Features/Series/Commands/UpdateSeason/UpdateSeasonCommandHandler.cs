using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.UpdateSeason;
public class UpdateSeasonCommandHandler : IRequestHandler<UpdateSeasonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSeasonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        series.UpdateSeason(
            request.SeasonId, request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, request.SeasonNumber, request.EpisodesCount);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
