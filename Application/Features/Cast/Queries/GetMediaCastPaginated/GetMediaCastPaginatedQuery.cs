using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public record GetMediaCastPaginatedQuery(int Page, int PageSize) : IRequest<(List<CastEntity> Items, int TotalCount)>
{


}
