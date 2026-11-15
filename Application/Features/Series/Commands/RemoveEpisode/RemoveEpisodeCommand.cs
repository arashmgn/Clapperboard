namespace IMDB.Application.Features.Series.Commands.RemoveEpisode;
public record RemoveEpisodeCommand(Guid SeriesId, Guid SeasonId, Guid EpisodeId) : IRequest<bool>;
