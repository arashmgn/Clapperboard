using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Commands.CreateCast;
public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, int>
{
}
