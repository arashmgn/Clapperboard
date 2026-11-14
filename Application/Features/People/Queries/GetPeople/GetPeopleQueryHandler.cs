using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeople;
public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<Person>>
{
    private readonly IApplicationDbContext _context;

    public GetPeopleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .OrderBy(x => x.FullName)
            .ToListAsync(cancellationToken);
    }
}
