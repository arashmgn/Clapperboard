namespace IMDB.Application.Features.Cast.Queries.GetMediaCast;
public class GetMediaCastQueryHandler : IRequestHandler<GetMediaCastQuery, List<CastDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMediaCastQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CastDto>> Handle(GetMediaCastQuery request, CancellationToken cancellationToken)
    {
        return await _context.Casts
            .AsNoTracking()
            .Where(c => c.MediaId == request.MediaId)
            .OrderBy(c => c.Role)
            .ThenBy(c => c.Person!.FullName)
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
