using MediatR;

namespace IMDB.Application.Genres.Commands.CreateGenre
{
    public record CreateGenreCommand : IRequest<int>
    {
    }
}
