using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesPaginated;

public class GetSeriesPaginatedQueryHandler : IRequestHandler<GetSeriesPaginatedQuery, (List<SeriesEntity> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetSeriesPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<SeriesEntity> Items, int TotalCount)> Handle(GetSeriesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Series.CountAsync(cancellationToken);

        var items = await _context.Series
            .AsNoTracking()
            .Include(s => s.Genres)
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
