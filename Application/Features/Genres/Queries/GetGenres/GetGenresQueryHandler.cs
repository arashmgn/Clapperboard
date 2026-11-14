using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenres;
public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
{
    private readonly IApplicationDbContext _context;

    public GetGenresQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }
}
