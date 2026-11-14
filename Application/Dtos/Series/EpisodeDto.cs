namespace IMDB.Application.Dtos;

public sealed record EpisodeDto(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int EpisodeNumber,
    int? DurationMinutes,
    Guid SeasonId,
    string PosterUrl,
    double Rate);
