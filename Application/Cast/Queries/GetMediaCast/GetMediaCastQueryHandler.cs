using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCast;

public class GetMediaCastQueryHandler : IRequestHandler<GetMediaCastQuery, List<CastEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaCastQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CastEntity>> Handle(GetMediaCastQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cast
            .AsNoTracking()
            .Where(x => x.TargetType == request.TargetType && x.TargetId == request.TargetId)
            .OrderBy(x => x.Role)
            .ToListAsync(cancellationToken);
    }
}
