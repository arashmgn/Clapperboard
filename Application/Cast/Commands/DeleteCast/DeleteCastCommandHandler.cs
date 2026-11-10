using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Cast.Commands.DeleteCast;
public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand, bool>
{
}
