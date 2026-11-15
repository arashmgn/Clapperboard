using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Series.Commands.AddSeason;
public class AddSeasonCommandHandler : IRequestHandler<AddSeasonCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddSeasonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(AddSeasonCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.GetSeriesWithSeasonsAsync(request.SeriesId, cancellationToken);

        var season = series.AddSeason(
            request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, request.SeasonNumber, request.EpisodesCount);
        await _context.SaveChangesAsync(cancellationToken);

        return season.Id;
    }
}
