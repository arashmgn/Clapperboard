using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPersonById;
public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person?>
{
    private readonly IApplicationDbContext _context;

    public GetPersonByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.People
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
