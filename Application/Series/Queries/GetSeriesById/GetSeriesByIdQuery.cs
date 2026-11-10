using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesById;
public record GetSeriesByIdQuery : IRequest<SeriesEntity?>
{
}
