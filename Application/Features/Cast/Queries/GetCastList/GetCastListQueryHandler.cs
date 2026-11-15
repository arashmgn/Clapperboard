namespace IMDB.Application.Features.Cast.Queries.GetCastList;
public class GetCastListQueryHandler : IRequestHandler<GetCastListQuery, List<CastDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCastListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CastDto>> Handle(GetCastListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Casts
            .AsNoTracking()
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
