using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Rates.Queries.GetMediaRates;
public class GetMediaRatesQueryHandler : IRequestHandler<GetMediaRatesQuery, List<RateDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetMediaRatesQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<List<RateDto>> Handle(GetMediaRatesQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Rates
            .AsNoTracking()
            .Where(x => x.MediaId == request.MediaId)
            .OrderBy(x => x.CreatedOn)
            .ProjectTo<RateDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await _identity.WithUserNamesAsync(items, cancellationToken);
    }
}
