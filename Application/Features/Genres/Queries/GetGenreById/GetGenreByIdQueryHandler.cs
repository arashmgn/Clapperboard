namespace IMDB.Application.Features.Genres.Queries.GetGenreById;
public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenreDto?> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Genres
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
