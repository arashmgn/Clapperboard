using MediatR;

namespace IMDB.Application.Movies.Commands.UpdateMovie;
public record UpdateMovieCommand : IRequest<bool>
{
}
