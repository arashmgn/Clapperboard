namespace IMDB.Application.Features.Series.Queries.GetSeriesPaginated;
public class GetSeriesPaginatedQueryHandler : IRequestHandler<GetSeriesPaginatedQuery, (List<SeriesDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<SeriesDto> Items, int TotalCount)> Handle(GetSeriesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Series.CountAsync(cancellationToken);

        var items = await _context.Series
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<SeriesDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
