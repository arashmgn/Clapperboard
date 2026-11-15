using IMDB.Domain.Enums;

namespace IMDB.Application.Features.Cast.Commands.CreateCast;
public record CreateCastCommand(Guid MediaId, Guid PersonId, CastRole Role) : IRequest<Guid>;
