using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastPaginated;
public class GetCastPaginatedQueryHandler : IRequestHandler<GetCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetCastPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<CastEntity> Items, int TotalCount)> Handle(GetCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = _context.Casts.Count();
        return (await _context.Casts
            .AsNoTracking()
            .Skip((request.page - 1) * request.pageSize)
            .Take(request.pageSize)
            .ToListAsync(cancellationToken), totalCount);
    }
}
