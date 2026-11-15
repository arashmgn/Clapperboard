namespace IMDB.Application.Features.People.Queries.GetPeople;
public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<PersonDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPeopleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PersonDto>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .OrderBy(x => x.FullName)
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
