namespace IMDB.Application.Dtos;

public sealed record SeriesRequestDto(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds);
