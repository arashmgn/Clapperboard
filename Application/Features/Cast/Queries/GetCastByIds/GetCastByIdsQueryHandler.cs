using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastByIds;

public class GetCastByIdsQueryHandler : IRequestHandler<GetCastByIdsQuery, List<CastEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCastByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CastEntity>> Handle(GetCastByIdsQuery request, CancellationToken cancellationToken)
    {
         return await _context.Casts
            .AsNoTracking()
            .Include(c => c.Person)
            .Where(c => request.Ids.Contains(c.Id))
            .ToListAsync(cancellationToken);

    }
}
