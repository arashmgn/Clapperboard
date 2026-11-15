namespace IMDB.Application.Features.Movies.Commands.DeleteMovie;
public record DeleteMovieCommand(Guid Id) : IRequest<bool>;
