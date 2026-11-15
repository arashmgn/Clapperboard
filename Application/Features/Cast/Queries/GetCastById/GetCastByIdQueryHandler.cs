namespace IMDB.Application.Features.Cast.Queries.GetCastById;
public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, CastDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCastByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CastDto?> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Casts
            .AsNoTracking()
            .Where(c => c.Id == request.Id)
            .ProjectTo<CastDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
