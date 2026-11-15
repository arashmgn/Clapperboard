using IMDB.Domain.Common;
using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Commands.CreateGenre;
public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateGenreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = Genre.Create(request.Title);

        var titleTaken = await _context.Genres
            .AnyAsync(g => g.Title == genre.Title, cancellationToken);
        if (titleTaken)
            throw new DomainException($"Genre '{genre.Title}' already exists.");

        _context.Genres.Add(genre);
        await _context.SaveChangesAsync(cancellationToken);

        return genre.Id;
    }
}
