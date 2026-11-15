using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Rates.Queries.GetRates;
public class GetRatesQueryHandler : IRequestHandler<GetRatesQuery, List<RateDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetRatesQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<RateDto>> Handle(GetRatesQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Rates
            .AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .ProjectTo<RateDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
