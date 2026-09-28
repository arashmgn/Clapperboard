using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesById;

public class GetSeriesByIdQueryHandler : IRequestHandler<GetSeriesByIdQuery, SeriesEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetSeriesByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SeriesEntity?> Handle(GetSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .Include(s => s.Genres)
            .Include(s => s.Seasons)
                .ThenInclude(se => se.Episodes)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
