namespace IMDB.Application.Dtos;

public sealed record SeasonRequestDto(
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    string PosterUrl,
    double Rate,
    int SeasonNumber,
    int EpisodesCount);
