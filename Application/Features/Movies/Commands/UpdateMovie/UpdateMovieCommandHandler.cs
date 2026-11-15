using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;
using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Features.Movies.Commands.UpdateMovie;
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Movie {request.Id} was not found.");

        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.Movies
            .AnyAsync(m => m.Id != request.Id && m.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A movie with IMDB ID {request.ImdbId} already exists.");

        var genres = await _context.GetGenresAsync(request.GenreIds, cancellationToken);

        movie.Update(
            request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.Duration, request.PosterUrl, request.Rate, genres);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
