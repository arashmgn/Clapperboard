using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesPaginated;
public record GetSeriesPaginatedQuery : IRequest<(List<SeriesEntity> Items, int TotalCount)>
{
}
