namespace IMDB.Application.Features.Series.Commands.UpdateEpisode;
public record UpdateEpisodeCommand(Guid SeriesId, Guid SeasonId, Guid EpisodeId, string ImdbId, string Title, DateTime ReleaseDate, string Description, string PosterUrl, double Rate, int EpisodeNumber, int? DurationMinutes) : IRequest<bool>;
