using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetCastById;
public record GetCastByIdQuery(Guid Id) : IRequest<CastEntity?>
{

}
