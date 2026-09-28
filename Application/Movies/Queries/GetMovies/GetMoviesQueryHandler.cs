using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMovies;

public class GetMoviesQueryHandler: IRequestHandler<GetMoviesQuery, List<Movie>>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
        .AsNoTracking()
        .Include(m => m.Genres)
        .ToListAsync(cancellationToken);
    }
}