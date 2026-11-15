namespace IMDB.Application.Features.Genres.Queries.GetGenresPaginated;
public class GetGenresPaginatedQueryHandler : IRequestHandler<GetGenresPaginatedQuery, (List<GenreDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenresPaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<GenreDto> Items, int TotalCount)> Handle(GetGenresPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Genres.CountAsync(cancellationToken);

        var items = await _context.Genres
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
