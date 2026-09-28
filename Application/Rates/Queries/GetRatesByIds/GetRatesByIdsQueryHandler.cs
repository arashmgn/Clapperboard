using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRatesByIds;

public class GetRatesByIdsQueryHandler : IRequestHandler<GetRatesByIdsQuery, List<Rate>>
{
    private readonly IApplicationDbContext _context;

    public GetRatesByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rate>> Handle(GetRatesByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rates
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
