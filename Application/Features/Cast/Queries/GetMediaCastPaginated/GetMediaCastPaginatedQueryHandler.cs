namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public class GetMediaCastPaginatedQueryHandler : IRequestHandler<GetMediaCastPaginatedQuery, (List<CastDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMediaCastPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<CastDto> Items, int TotalCount)> Handle(GetMediaCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Casts
            .AsNoTracking()
            .Where(c => c.MediaId == request.MediaId);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Role)
            .ThenBy(c => c.Person!.FullName)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
