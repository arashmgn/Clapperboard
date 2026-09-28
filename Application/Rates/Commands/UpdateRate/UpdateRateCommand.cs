using MediatR;

namespace IMDB.Application.Rates.Commands.UpdateRate;

public record UpdateRateCommand(int Id, string UserId, int Score) : IRequest<bool>;
