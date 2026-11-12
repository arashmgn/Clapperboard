using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public record GetMediaCastPaginatedQuery : IRequest<(List<CastEntity> Items, int TotalCount)>
{
}
