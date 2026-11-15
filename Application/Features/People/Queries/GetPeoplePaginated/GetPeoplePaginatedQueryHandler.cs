namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public class GetPeoplePaginatedQueryHandler : IRequestHandler<GetPeoplePaginatedQuery, (List<PersonDto> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPeoplePaginatedQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<(List<PersonDto> Items, int TotalCount)> Handle(GetPeoplePaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.People.CountAsync(cancellationToken);

        var items = await _context.People
            .AsNoTracking()
            .OrderBy(x => x.FullName)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
