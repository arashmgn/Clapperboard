namespace IMDB.Application.Features.Rates.Commands.DeleteRate;
public record DeleteRateCommand(Guid Id) : IRequest<bool>;
