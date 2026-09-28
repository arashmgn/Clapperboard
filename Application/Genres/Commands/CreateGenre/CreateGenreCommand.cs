using MediatR;

namespace IMDB.Application.Genres.Commands.CreateGenre
{
    public record CreateGenreCommand(string Title) : IRequest<int>;
}