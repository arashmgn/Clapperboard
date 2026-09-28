using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetMediaRates;

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
            .Where(x => x.TargetType == request.TargetType && x.TargetId == request.TargetId)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
