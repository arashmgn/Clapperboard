using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastByIds;

public class GetCastByIdsQueryHandler : IRequestHandler<GetCastByIdsQuery, List<CastEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCastByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CastEntity>> Handle(GetCastByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cast
            .AsNoTracking()
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
