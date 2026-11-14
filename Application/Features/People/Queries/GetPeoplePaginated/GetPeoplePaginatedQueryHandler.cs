using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public class GetPeoplePaginatedQueryHandler : IRequestHandler<GetPeoplePaginatedQuery, (List<Person> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetPeoplePaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Person> Items, int TotalCount)> Handle(GetPeoplePaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.People.CountAsync(cancellationToken);

        var items = await _context.People
            .AsNoTracking()
            .OrderBy(x => x.FullName)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
