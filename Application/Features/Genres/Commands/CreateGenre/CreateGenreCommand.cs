namespace IMDB.Application.Features.Genres.Commands.CreateGenre;
public record CreateGenreCommand(string Title) : IRequest<Guid>;
