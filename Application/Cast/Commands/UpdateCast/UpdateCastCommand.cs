using api.Enums;
using MediatR;

namespace IMDB.Application.Cast.Commands.UpdateCast;
public record UpdateCastCommand : IRequest<bool>
{
}
