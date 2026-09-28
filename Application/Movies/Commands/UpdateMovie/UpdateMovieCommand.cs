using MediatR;

namespace IMDB.Application.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(
    int Id,
    string ImdbId,
    string Title,
    string Description,
    string PosterUrl,
    DateTime ReleaseDate,
    int DurationMinutes) : IRequest<bool>;
