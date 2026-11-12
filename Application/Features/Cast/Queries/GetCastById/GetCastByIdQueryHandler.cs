using CastEntity = IMDB.Domain.Entities.Cast;
using IMDB.Application.Common.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Features.Cast.Queries.GetCastById;
public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, CastEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetCastByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CastEntity?> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Casts
            .AsNoTracking()
            .Include(c => c.Person)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
    }
}
