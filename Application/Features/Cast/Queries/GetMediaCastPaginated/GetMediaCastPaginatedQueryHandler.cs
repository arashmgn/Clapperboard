using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public class GetMediaCastPaginatedQueryHandler : IRequestHandler<GetMediaCastPaginatedQuery, (List<CastEntity> Items, int TotalCount)>
{
}
