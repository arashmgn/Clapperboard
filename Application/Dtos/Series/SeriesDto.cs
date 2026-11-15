namespace IMDB.Application.Dtos;

public sealed record SeriesDto(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    IReadOnlyList<GenreDto> Genres,
    string PosterUrl,
    double Rate);
