using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesById;
public record GetSeriesByIdQuery : IRequest<SeriesEntity?>
{
}
