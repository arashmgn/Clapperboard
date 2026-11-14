using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public class GetMediaCastPaginatedQueryHandler : IRequestHandler<GetMediaCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetMediaCastPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<CastEntity> Items, int TotalCount)> Handle(GetMediaCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Casts.AsQueryable();
        query = query.OrderBy(c => c.PersonId)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize);
        var items = await query.ToListAsync(cancellationToken);
        var totalCount = await _context.Casts.CountAsync(cancellationToken);
        return (items, totalCount);
    }
}
