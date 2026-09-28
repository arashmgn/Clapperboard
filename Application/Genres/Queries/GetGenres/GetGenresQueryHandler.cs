using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
    {
        private readonly IApplicationDbContext _context;

        public GetGenresQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return await _context.Genres.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
