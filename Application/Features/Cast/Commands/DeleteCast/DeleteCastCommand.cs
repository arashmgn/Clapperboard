namespace IMDB.Application.Features.Cast.Commands.DeleteCast;
public record DeleteCastCommand(Guid Id) : IRequest<bool>
{
}
