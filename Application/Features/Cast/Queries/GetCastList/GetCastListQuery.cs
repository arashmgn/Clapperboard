using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastList;
public record GetCastListQuery : IRequest<List<CastEntity>>
{
}
