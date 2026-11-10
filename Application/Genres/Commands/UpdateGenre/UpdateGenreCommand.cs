using MediatR;

namespace IMDB.Application.Genres.Commands.UpdateGenre
{
    public record UpdateGenreCommand : IRequest<bool>
    {
    }
}
