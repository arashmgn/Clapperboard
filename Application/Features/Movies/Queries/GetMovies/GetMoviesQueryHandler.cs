using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMovies;
public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Movie>>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .Include(x => x.Genres)
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }
}
