namespace IMDB.Application.Features.Movies.Commands.UpdateMovie;
public record UpdateMovieCommand(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int Duration,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds) : IRequest<bool>;
