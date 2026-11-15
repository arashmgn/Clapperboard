namespace IMDB.Application.Features.Series.Queries.GetSeriesById;
public class GetSeriesByIdQueryHandler : IRequestHandler<GetSeriesByIdQuery, SeriesDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SeriesDto?> Handle(GetSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<SeriesDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
