using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.UpdateRate;
public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, bool>
{
}
