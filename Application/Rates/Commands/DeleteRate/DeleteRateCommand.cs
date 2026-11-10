using MediatR;

namespace IMDB.Application.Rates.Commands.DeleteRate;
public record DeleteRateCommand : IRequest<bool>
{
}
