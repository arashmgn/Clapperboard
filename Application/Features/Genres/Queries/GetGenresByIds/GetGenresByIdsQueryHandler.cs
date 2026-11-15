namespace IMDB.Application.Features.Genres.Queries.GetGenresByIds;
public class GetGenresByIdsQueryHandler : IRequestHandler<GetGenresByIdsQuery, List<GenreDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenresByIdsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GenreDto>> Handle(GetGenresByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
