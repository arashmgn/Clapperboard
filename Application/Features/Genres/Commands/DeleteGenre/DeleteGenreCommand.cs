namespace IMDB.Application.Features.Genres.Commands.DeleteGenre;
public record DeleteGenreCommand(Guid Id) : IRequest<bool>;
