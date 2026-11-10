using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Cast.Commands.UpdateCast;
public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, bool>
{
}
