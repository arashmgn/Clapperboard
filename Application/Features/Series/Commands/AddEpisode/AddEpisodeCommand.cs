namespace IMDB.Application.Features.Series.Commands.AddEpisode;
public record AddEpisodeCommand(Guid SeriesId, Guid SeasonId, string ImdbId, string Title, DateTime ReleaseDate, string Description, string PosterUrl, double Rate, int EpisodeNumber, int? DurationMinutes) : IRequest<Guid>;
