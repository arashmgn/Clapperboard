namespace IMDB.Application.Dtos;

public sealed record EpisodeRequestDto(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    string PosterUrl,
    double Rate,
    int EpisodeNumber,
    int? DurationMinutes);
