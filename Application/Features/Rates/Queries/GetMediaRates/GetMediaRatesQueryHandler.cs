using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetMediaRates;
public class GetMediaRatesQueryHandler : IRequestHandler<GetMediaRatesQuery, List<Rate>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaRatesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rate>> Handle(GetMediaRatesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rates
            .AsNoTracking()
            .Where(r => r.MediaId == request.MediaId)
            .OrderBy(r => r.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
