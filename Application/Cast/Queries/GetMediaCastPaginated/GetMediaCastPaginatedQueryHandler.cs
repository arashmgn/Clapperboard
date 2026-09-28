using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCastPaginated;

public class GetMediaCastPaginatedQueryHandler : IRequestHandler<GetMediaCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetMediaCastPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<CastEntity> Items, int TotalCount)> Handle(GetMediaCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Cast
            .AsNoTracking()
            .Where(x => x.TargetType == request.TargetType && x.TargetId == request.TargetId);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(x => x.Role)
            .ThenBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
