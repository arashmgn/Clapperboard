using IMDB.Domain.Enums;

namespace IMDB.Application.Features.Cast.Commands.UpdateCast;
public record UpdateCastCommand(Guid Id, Guid MediaId, Guid PersonId, CastRole Role) : IRequest<bool>
{
}
