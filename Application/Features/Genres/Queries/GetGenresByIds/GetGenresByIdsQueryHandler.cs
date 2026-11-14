using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenresByIds;
public class GetGenresByIdsQueryHandler : IRequestHandler<GetGenresByIdsQuery, List<Genre>>
{
    private readonly IApplicationDbContext _context;

    public GetGenresByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> Handle(GetGenresByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
