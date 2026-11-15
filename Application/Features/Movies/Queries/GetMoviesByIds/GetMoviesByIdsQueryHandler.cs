namespace IMDB.Application.Features.Movies.Queries.GetMoviesByIds;
public class GetMoviesByIdsQueryHandler : IRequestHandler<GetMoviesByIdsQuery, List<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesByIdsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MovieDto>> Handle(GetMoviesByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
