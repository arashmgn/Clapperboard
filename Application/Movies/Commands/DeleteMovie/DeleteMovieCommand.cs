using MediatR;

namespace IMDB.Application.Movies.Commands.DeleteMovie;
public record DeleteMovieCommand : IRequest<bool>
{
}
