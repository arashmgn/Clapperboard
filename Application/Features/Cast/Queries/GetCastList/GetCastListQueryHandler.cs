using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastList;
public class GetCastListQueryHandler : IRequestHandler<GetCastListQuery, List<CastEntity>>
{
}
