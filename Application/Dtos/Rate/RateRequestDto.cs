using IMDB.Domain.Enums;

namespace IMDB.Application.Dtos;

public sealed record RateRequestDto(ScoreEnum Score);
