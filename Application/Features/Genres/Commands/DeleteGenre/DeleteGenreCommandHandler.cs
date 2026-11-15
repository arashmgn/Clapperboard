using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Genres.Commands.DeleteGenre;
public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _context.Genres
            .FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Genre {request.Id} was not found.");

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
