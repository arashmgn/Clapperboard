using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesPaginated;
public record GetSeriesPaginatedQuery : IRequest<(List<SeriesEntity> Items, int TotalCount)>
{
}
