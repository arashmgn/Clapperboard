using api.Enums;
using MediatR;

namespace IMDB.Application.Rates.Commands.CreateRate;

public record CreateRateCommand(
    string UserId,
    ReviewTargetType TargetType,
    int TargetId,
    int Score) : IRequest<int>;
