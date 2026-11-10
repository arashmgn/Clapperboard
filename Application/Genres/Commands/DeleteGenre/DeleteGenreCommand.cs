using MediatR;

namespace IMDB.Application.Genres.Commands.DeleteGenre
{
    public record DeleteGenreCommand : IRequest<bool>
    {
    }
}
