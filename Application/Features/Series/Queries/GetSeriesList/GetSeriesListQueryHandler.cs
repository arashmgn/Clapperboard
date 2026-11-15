namespace IMDB.Application.Features.Series.Queries.GetSeriesList;
public class GetSeriesListQueryHandler : IRequestHandler<GetSeriesListQuery, List<SeriesDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SeriesDto>> Handle(GetSeriesListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ProjectTo<SeriesDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
