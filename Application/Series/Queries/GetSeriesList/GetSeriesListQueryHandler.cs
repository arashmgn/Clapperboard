using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesList;

public class GetSeriesListQueryHandler : IRequestHandler<GetSeriesListQuery, List<SeriesEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetSeriesListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SeriesEntity>> Handle(GetSeriesListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .AsNoTracking()
            .Include(s => s.Genres)
            .ToListAsync(cancellationToken);
    }
}
