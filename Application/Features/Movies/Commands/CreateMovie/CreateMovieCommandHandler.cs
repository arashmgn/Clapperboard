using IMDB.Application.Common.Extensions;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Features.Movies.Commands.CreateMovie;
public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.Movies
            .AnyAsync(m => m.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A movie with IMDB ID {request.ImdbId} already exists.");

        var genres = await _context.GetGenresAsync(request.GenreIds, cancellationToken);

        var movie = Movie.Create(
            request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.Duration, request.PosterUrl, request.Rate, genres);
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
