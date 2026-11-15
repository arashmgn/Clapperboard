namespace IMDB.Application.Features.Series.Commands.AddSeason;
public record AddSeasonCommand(Guid SeriesId, string ImdbId, string Title, DateTime ReleaseDate, string Description, string PosterUrl, double Rate, int SeasonNumber, int EpisodesCount) : IRequest<Guid>;
