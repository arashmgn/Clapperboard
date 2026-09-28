using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
// The namespace IMDB.Application.Series hides the entity name, so the entity gets an alias.
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Commands.CreateSeries;

public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var genreIds = request.GenreIds.Distinct().ToList();
        var genres = await _context.Genres
            .Where(g => genreIds.Contains(g.Id))
            .ToListAsync(cancellationToken);

        if (genres.Count != genreIds.Count)
            throw new KeyNotFoundException("One or more genres were not found.");

        var info = new MediaInfo(request.ImdbId, request.Title, request.Description, request.PosterUrl, request.ReleaseDate);
        var series = SeriesEntity.Create(info);
        foreach (var genre in genres)
            series.AddGenre(genre);

        _context.Series.Add(series);
        await _context.SaveChangesAsync(cancellationToken);

        return series.Id;
    }
}
