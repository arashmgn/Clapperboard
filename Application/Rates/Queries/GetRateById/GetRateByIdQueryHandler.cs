using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRateById;

public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, Rate?>
{
    private readonly IApplicationDbContext _context;

    public GetRateByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Rate?> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
