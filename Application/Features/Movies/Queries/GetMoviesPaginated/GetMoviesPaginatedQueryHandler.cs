using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, (List<Movie> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Movie> Items, int TotalCount)> Handle(GetMoviesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Movies.CountAsync(cancellationToken);

        var items = await _context.Movies
            .AsNoTracking()
            .Include(x => x.Genres)
            .OrderBy(x => x.Title)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
