namespace IMDB.Application.Features.Genres.Queries.GetGenres;
public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<GenreDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenresQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GenreDto>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
