using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPeoplePaginated;

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
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
