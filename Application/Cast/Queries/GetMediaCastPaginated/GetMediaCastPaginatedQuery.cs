using api.Enums;
using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetMediaCastPaginated;

public record GetMediaCastPaginatedQuery(ReviewTargetType TargetType, int TargetId, int Page, int PageSize)
    : IRequest<(List<CastEntity> Items, int TotalCount)>;
