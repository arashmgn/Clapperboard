using api.Enums;
using MediatR;

namespace IMDB.Application.Cast.Commands.CreateCast;
public record CreateCastCommand : IRequest<int>
{
}
