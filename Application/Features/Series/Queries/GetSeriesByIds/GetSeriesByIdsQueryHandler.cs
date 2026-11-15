namespace IMDB.Application.Features.Series.Queries.GetSeriesByIds;
public class GetSeriesByIdsQueryHandler : IRequestHandler<GetSeriesByIdsQuery, List<SeriesDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesByIdsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SeriesDto>> Handle(GetSeriesByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<SeriesDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
