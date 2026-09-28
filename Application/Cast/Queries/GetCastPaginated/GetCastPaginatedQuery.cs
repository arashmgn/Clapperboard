using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastPaginated;

public record GetCastPaginatedQuery(int Page, int PageSize) : IRequest<(List<CastEntity> Items, int TotalCount)>;
