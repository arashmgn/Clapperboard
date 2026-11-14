using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenresPaginated;
public class GetGenresPaginatedQueryHandler : IRequestHandler<GetGenresPaginatedQuery, (List<Genre> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetGenresPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Genre> Items, int TotalCount)> Handle(GetGenresPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Genres.CountAsync(cancellationToken);

        var items = await _context.Genres
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
