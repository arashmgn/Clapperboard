using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCast;
public class GetMediaCastQueryHandler : IRequestHandler<GetMediaCastQuery, List<CastEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaCastQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CastEntity>> Handle(GetMediaCastQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Casts.AsQueryable();
        query = query.OrderBy(c => c.PersonId);
        return await query.ToListAsync(cancellationToken);
    }
}
