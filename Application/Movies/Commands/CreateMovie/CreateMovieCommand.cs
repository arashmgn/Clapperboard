using MediatR;

namespace IMDB.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand(
    string ImdbId,
    string Title,
    string Description,
    string PosterUrl,
    DateTime ReleaseDate,
    int DurationMinutes,
    List<int> GenreIds) : IRequest<int>;
