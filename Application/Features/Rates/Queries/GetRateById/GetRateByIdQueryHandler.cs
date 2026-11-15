using IMDB.Application.Common.Extensions;

namespace IMDB.Application.Features.Rates.Queries.GetRateById;
public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, RateDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identity;

    public GetRateByIdQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identity)
    {
        _context = context;
        _mapper = mapper;
        _identity = identity;
    }

    public async Task<RateDto?> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _context.Rates
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<RateDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return await _identity.WithUserNameAsync(item, cancellationToken);
    }
}
