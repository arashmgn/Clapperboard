namespace IMDB.Application.Features.Movies.Queries.GetMovies;
public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
