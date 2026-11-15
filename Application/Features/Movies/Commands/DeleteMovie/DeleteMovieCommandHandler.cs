using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Movies.Commands.DeleteMovie;
public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Movie {request.Id} was not found.");

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
