using MediatR;

namespace IMDB.Application.Rates.Commands.UpdateRate;

// UserId is the current user; only the owner may change the rate.
public record UpdateRateCommand(int Id, string UserId, int Score) : IRequest<bool>;
