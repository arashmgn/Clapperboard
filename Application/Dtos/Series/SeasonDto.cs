namespace IMDB.Application.Dtos;

public sealed record SeasonDto(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    int SeasonNumber,
    int EpisodesCount,
    Guid SeriesId,
    string PosterUrl,
    double Rate,
    IReadOnlyList<EpisodeDto> Episodes);
