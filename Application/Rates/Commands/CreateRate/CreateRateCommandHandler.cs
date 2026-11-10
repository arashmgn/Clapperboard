using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.CreateRate;
public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, int>
{
}
