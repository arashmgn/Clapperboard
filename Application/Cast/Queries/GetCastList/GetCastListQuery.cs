using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastList;
public record GetCastListQuery : IRequest<List<CastEntity>>
{
}
