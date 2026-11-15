using IMDB.Domain.Enums;

namespace IMDB.Application.Features.Rates.Commands.CreateRate;
public record CreateRateCommand(Guid MediaId, ScoreEnum Score) : IRequest<Guid>;
