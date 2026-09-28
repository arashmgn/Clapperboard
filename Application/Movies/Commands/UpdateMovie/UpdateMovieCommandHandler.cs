using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (movie is null)
            return false;

        var info = new MediaInfo(request.ImdbId, request.Title, request.Description, request.PosterUrl, request.ReleaseDate);
        movie.Update(info, request.DurationMinutes);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
