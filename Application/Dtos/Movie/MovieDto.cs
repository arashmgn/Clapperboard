namespace IMDB.Application.Dtos;

public sealed record MovieDto(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int Duration,
    IReadOnlyList<GenreDto> Genres,
    string PosterUrl,
    double Rate);
