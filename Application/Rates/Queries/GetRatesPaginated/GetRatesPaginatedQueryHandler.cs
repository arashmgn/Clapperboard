using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRatesPaginated;

public class GetRatesPaginatedQueryHandler : IRequestHandler<GetRatesPaginatedQuery, (List<Rate> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetRatesPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Rate> Items, int TotalCount)> Handle(GetRatesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Rates.CountAsync(cancellationToken);

        var items = await _context.Rates
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
