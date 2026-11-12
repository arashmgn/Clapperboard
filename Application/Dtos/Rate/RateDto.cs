using IMDB.Domain.Enums;

namespace IMDB.Application.Dtos;

public sealed record RateDto(Guid Id, Guid MediaId, string UserId, string? UserName, ScoreEnum Score);
