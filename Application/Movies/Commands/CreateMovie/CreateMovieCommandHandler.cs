using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var genreIds = request.GenreIds.Distinct().ToList();
        var genres = await _context.Genres
            .Where(g => genreIds.Contains(g.Id))
            .ToListAsync(cancellationToken);

        if (genres.Count != genreIds.Count)
            throw new KeyNotFoundException("One or more genres were not found.");

        var info = new MediaInfo(request.ImdbId, request.Title, request.Description, request.PosterUrl, request.ReleaseDate);
        var movie = Movie.Create(info, request.DurationMinutes);
        foreach (var genre in genres)
            movie.AddGenre(genre);

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
