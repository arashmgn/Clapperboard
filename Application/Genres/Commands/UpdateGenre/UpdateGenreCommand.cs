using MediatR;

namespace IMDB.Application.Genres.Commands.UpdateGenre
{
    public record UpdateGenreCommand(int Id, string Title) : IRequest<bool>;
}