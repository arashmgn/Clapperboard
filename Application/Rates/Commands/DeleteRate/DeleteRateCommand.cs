using MediatR;

namespace IMDB.Application.Rates.Commands.DeleteRate;

// UserId is the current user; only the owner may delete the rate.
public record DeleteRateCommand(int Id, string UserId) : IRequest<bool>;
