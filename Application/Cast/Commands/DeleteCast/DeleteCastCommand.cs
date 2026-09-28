using MediatR;

namespace IMDB.Application.Cast.Commands.DeleteCast;

public record DeleteCastCommand(int Id) : IRequest<bool>;
