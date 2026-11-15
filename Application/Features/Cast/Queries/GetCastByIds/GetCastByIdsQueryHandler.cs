namespace IMDB.Application.Features.Cast.Queries.GetCastByIds;
public class GetCastByIdsQueryHandler : IRequestHandler<GetCastByIdsQuery, List<CastDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCastByIdsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CastDto>> Handle(GetCastByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Casts
            .AsNoTracking()
            .Where(c => request.Ids.Contains(c.Id))
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
