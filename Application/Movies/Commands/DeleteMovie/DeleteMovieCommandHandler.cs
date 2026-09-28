using api.Enums;
using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (movie is null)
            return false;

        await _context.RemoveTargetDependentsAsync(ReviewTargetType.Movie, new[] { movie.Id }, cancellationToken);
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
