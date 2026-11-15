namespace IMDB.Application.Features.Seasons.Queries.GetSeasonById;
public class GetSeasonByIdQueryHandler : IRequestHandler<GetSeasonByIdQuery, SeasonDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeasonByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SeasonDto?> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Seasons
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<SeasonDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
