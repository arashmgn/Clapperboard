using MediatR;

namespace IMDB.Application.Genres.Commands.DeleteGenre
{
    public record DeleteGenreCommand(int Id) : IRequest<bool>;
}
