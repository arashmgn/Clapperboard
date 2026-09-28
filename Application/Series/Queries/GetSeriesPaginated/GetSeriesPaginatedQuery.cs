using MediatR;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Queries.GetSeriesPaginated;

public record GetSeriesPaginatedQuery(int Page, int PageSize) : IRequest<(List<SeriesEntity> Items, int TotalCount)>;
