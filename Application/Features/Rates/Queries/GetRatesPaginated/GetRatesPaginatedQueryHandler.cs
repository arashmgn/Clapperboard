using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
public class GetRatesPaginatedQueryHandler : IRequestHandler<GetRatesPaginatedQuery, (List<RateDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetRatesPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<(List<RateDto> Items, int TotalCount)> Handle(GetRatesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Rates.CountAsync(cancellationToken);

        var items = await _context.Rates
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<RateDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (await _identity.WithUserNamesAsync(items, cancellationToken), totalCount);
    }
}
