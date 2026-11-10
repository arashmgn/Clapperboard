using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.DeleteRate;
public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand, bool>
{
}
