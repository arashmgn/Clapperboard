using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Rates.Queries.GetRatesByIds;
public class GetRatesByIdsQueryHandler : IRequestHandler<GetRatesByIdsQuery, List<RateDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetRatesByIdsQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<RateDto>> Handle(GetRatesByIdsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Rates
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<RateDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
