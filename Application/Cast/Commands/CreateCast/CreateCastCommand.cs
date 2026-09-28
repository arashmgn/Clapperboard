using api.Enums;
using MediatR;

namespace IMDB.Application.Cast.Commands.CreateCast;

public record CreateCastCommand(
    ReviewTargetType TargetType,
    int TargetId,
    int PersonId,
    CastRole Role) : IRequest<int>;
