namespace IMDB.Application.Features.Cast.Queries.GetCastPaginated;
public class GetCastPaginatedQueryHandler : IRequestHandler<GetCastPaginatedQuery, (List<CastDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCastPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<CastDto> Items, int TotalCount)> Handle(GetCastPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Casts.CountAsync(cancellationToken);

        var items = await _context.Casts
            .AsNoTracking()
            .OrderBy(c => c.PersonId)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
