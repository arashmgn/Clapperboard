using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre?>
    {
        private readonly IApplicationDbContext _context;

        public GetGenreByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre?> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
