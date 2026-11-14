using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRates;
public class GetRatesQueryHandler : IRequestHandler<GetRatesQuery, List<Rate>>
{
    private readonly IApplicationDbContext _context;

    public GetRatesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rate>> Handle(GetRatesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rates
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
