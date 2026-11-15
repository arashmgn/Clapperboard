using IMDB.Domain.Enums;

namespace IMDB.Application.Features.Rates.Commands.UpdateRate;
public record UpdateRateCommand(Guid Id, ScoreEnum Score) : IRequest<bool>;
