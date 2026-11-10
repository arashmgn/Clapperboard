using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastByIds;
public record GetCastByIdsQuery : IRequest<List<CastEntity>>
{
}
