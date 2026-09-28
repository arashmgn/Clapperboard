using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesByIds;

public class GetSeriesByIdsQueryHandler : IRequestHandler<GetSeriesByIdsQuery, List<SeriesEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetSeriesByIdsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SeriesEntity>> Handle(GetSeriesByIdsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .Include(s => s.Genres)
            .Where(x => request.Ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
