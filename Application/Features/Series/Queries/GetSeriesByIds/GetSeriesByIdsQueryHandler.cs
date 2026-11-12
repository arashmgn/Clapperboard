using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesByIds;
public class GetSeriesByIdsQueryHandler : IRequestHandler<GetSeriesByIdsQuery, List<SeriesEntity>>
{
}
