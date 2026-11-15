namespace IMDB.Application.Features.People.Queries.GetPersonById;
public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonDto?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
