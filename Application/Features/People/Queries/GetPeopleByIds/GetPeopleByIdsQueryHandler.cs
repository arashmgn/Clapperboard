using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeopleByIds;
public class GetPeopleByIdsQueryHandler : IRequestHandler<GetPeopleByIdsQuery, List<Person>>
{
    private readonly IApplicationDbContext _context;

    public GetPeopleByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(GetPeopleByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
