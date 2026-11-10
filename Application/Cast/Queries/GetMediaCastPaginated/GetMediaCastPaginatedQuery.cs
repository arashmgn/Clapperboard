using api.Enums;
using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCastPaginated;
public record GetMediaCastPaginatedQuery : IRequest<(List<CastEntity> Items, int TotalCount)>
{
}
