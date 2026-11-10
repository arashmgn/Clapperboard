using MediatR;

namespace IMDB.Application.Rates.Commands.UpdateRate;
public record UpdateRateCommand : IRequest<bool>
{
}
