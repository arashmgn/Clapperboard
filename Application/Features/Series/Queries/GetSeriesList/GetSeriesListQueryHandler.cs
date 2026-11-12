using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesList;
public class GetSeriesListQueryHandler : IRequestHandler<GetSeriesListQuery, List<SeriesEntity>>
{
}
