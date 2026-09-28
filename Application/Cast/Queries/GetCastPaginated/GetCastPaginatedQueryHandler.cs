using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastPaginated;

public class GetCastPaginatedQueryHandler : IRequestHandler<GetCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetCastPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<CastEntity> Items, int TotalCount)> Handle(GetCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Cast.CountAsync(cancellationToken);

        var items = await _context.Cast
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
