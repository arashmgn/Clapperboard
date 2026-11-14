namespace IMDB.Application.Features.Genres.Commands.UpdateGenre;
public record UpdateGenreCommand(Guid Id, string Title) : IRequest<bool>;
