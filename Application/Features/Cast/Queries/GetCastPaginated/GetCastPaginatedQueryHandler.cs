using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastPaginated;
public class GetCastPaginatedQueryHandler : IRequestHandler<GetCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
}
