using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Features.Series.Queries.GetSeriesPaginated;
public class GetSeriesPaginatedQueryHandler : IRequestHandler<GetSeriesPaginatedQuery, (List<SeriesEntity> Items, int TotalCount)>
{
}
