namespace IMDB.Application.Dtos;

public sealed record MovieRequestDto(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int Duration,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds);
