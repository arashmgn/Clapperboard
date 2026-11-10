using MediatR;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Queries.GetCastById;
public record GetCastByIdQuery : IRequest<CastEntity?>
{
}
