namespace IMDB.Application.Features.Series.Commands.RemoveSeason;
public record RemoveSeasonCommand(Guid SeriesId, Guid SeasonId) : IRequest<bool>;
