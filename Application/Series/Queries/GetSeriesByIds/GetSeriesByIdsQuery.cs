using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesByIds;

public record GetSeriesByIdsQuery(IEnumerable<int> Ids) : IRequest<List<SeriesEntity>>;
