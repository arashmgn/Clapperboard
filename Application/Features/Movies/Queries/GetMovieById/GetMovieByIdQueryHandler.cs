using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMovieById;
public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie?>
{
    private readonly IApplicationDbContext _context;

    public GetMovieByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Movie?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .Include(x => x.Genres)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
