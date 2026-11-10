using MediatR;

namespace IMDB.Application.Movies.Commands.CreateMovie;
public record CreateMovieCommand : IRequest<int>
{
}
