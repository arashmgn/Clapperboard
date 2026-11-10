using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesByIds;
public record GetSeriesByIdsQuery : IRequest<List<SeriesEntity>>
{
}
