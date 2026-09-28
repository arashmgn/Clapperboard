using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMoviesPaginated;

public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, (List<Movie> Items, int TotalCount)>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesPaginatedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(List<Movie> Items, int TotalCount)> Handle(GetMoviesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Movies.CountAsync(cancellationToken);

        var items = await _context.Movies
            .AsNoTracking()
            .Include(m => m.Genres)
            .OrderBy(x => x.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}
