using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastPaginated;
public record GetCastPaginatedQuery : IRequest<(List<CastEntity> Items, int TotalCount)>
{
}
