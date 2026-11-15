namespace IMDB.Application.Features.Seasons.Queries.GetSeasons;
public record GetSeasonsQuery(Guid? SeriesId = null) : IRequest<List<SeasonDto>>;
