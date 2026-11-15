namespace IMDB.Application.Features.Movies.Commands.CreateMovie;
public record CreateMovieCommand(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int Duration,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds) : IRequest<Guid>;
