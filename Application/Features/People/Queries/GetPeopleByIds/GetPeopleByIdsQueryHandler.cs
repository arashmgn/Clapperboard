namespace IMDB.Application.Features.People.Queries.GetPeopleByIds;
public class GetPeopleByIdsQueryHandler : IRequestHandler<GetPeopleByIdsQuery, List<PersonDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPeopleByIdsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PersonDto>> Handle(GetPeopleByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
