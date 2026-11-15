namespace IMDB.Application.Features.Seasons.Queries.GetSeasons;
public class GetSeasonsQueryHandler : IRequestHandler<GetSeasonsQuery, List<SeasonDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeasonsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SeasonDto>> Handle(GetSeasonsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Seasons.AsNoTracking();

        if (request.SeriesId is { } seriesId)
            query = query.Where(s => s.SeriesId == seriesId);

        return await query
            .OrderBy(s => s.SeriesId)
            .ThenBy(s => s.SeasonNumber)
            .ProjectTo<SeasonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
