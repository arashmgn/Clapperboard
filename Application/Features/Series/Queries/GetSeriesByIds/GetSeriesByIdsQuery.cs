using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesByIds;
public record GetSeriesByIdsQuery : IRequest<List<SeriesEntity>>
{
}
