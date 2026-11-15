namespace IMDB.Application.Features.Series.Commands.UpdateSeason;
public record UpdateSeasonCommand(Guid SeriesId, Guid SeasonId, string ImdbId, string Title, DateTime ReleaseDate, string Description, string PosterUrl, double Rate, int SeasonNumber, int EpisodesCount) : IRequest<bool>;
