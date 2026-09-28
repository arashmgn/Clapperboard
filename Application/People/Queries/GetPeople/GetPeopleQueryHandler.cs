using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPeople;

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<Person>>
{
    private readonly IApplicationDbContext _context;

    public GetPeopleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await _context.People.AsNoTracking().ToListAsync(cancellationToken);
    }
}
