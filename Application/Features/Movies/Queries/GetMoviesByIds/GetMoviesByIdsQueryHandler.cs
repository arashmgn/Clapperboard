using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesByIds;
public class GetMoviesByIdsQueryHandler : IRequestHandler<GetMoviesByIdsQuery, List<Movie>>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> Handle(GetMoviesByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .Include(x => x.Genres)
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
