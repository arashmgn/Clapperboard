using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRates;

public class GetRatesQueryHandler : IRequestHandler<GetRatesQuery, List<Rate>>
{
    private readonly IApplicationDbContext _context;

    public GetRatesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rate>> Handle(GetRatesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rates.AsNoTracking().ToListAsync(cancellationToken);
    }
}
