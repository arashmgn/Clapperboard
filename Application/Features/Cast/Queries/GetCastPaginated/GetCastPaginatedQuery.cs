using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastPaginated;
public record GetCastPaginatedQuery(int page, int pageSize) : IRequest<(List<CastEntity> Items, int TotalCount)>
{
}
