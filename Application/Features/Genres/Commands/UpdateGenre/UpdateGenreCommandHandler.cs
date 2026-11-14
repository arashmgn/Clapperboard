using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Genres.Commands.UpdateGenre;
public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _context.Genres
            .FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Genre {request.Id} was not found.");

        genre.Rename(request.Title);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
