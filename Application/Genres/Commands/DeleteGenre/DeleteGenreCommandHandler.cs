using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGenreCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (genre is null)
                return false;

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
