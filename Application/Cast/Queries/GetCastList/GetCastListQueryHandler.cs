using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastList;

public class GetCastListQueryHandler : IRequestHandler<GetCastListQuery, List<CastEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCastListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CastEntity>> Handle(GetCastListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cast.AsNoTracking().ToListAsync(cancellationToken);
    }
}
