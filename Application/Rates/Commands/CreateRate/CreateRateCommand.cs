using api.Enums;
using MediatR;

namespace IMDB.Application.Rates.Commands.CreateRate;
public record CreateRateCommand : IRequest<int>
{
}
