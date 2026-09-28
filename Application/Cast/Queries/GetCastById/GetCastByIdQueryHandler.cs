using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastById;

public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, CastEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetCastByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CastEntity?> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cast.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
