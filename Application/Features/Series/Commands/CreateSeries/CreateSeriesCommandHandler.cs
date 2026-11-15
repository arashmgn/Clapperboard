using IMDB.Application.Common.Extensions;
using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Commands.CreateSeries;
public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.Series
            .AnyAsync(s => s.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A series with IMDB ID {request.ImdbId} already exists.");

        var genres = await _context.GetGenresAsync(request.GenreIds, cancellationToken);

        var series = SeriesEntity.Create(
            request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, genres);
        _context.Series.Add(series);
        await _context.SaveChangesAsync(cancellationToken);

        return series.Id;
    }
}
