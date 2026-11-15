namespace IMDB.Application.Features.Movies.Queries.GetMovieById;
public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieDto?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
