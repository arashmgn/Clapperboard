using MediatR;

namespace IMDB.Application.Rates.Commands.DeleteRate;

public record DeleteRateCommand(int Id, string UserId) : IRequest<bool>;
