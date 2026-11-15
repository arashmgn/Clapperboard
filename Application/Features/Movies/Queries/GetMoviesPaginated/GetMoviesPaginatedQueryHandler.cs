namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, (List<MovieDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<MovieDto> Items, int TotalCount)> Handle(GetMoviesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Movies.CountAsync(cancellationToken);

        var items = await _context.Movies
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
