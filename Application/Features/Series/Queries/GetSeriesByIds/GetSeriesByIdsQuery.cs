namespace IMDB.Application.Features.Series.Queries.GetSeriesByIds;
public record GetSeriesByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<SeriesDto>>;
