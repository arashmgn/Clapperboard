using IMDB.Domain.Enums;

namespace IMDB.Application.Dtos;

public sealed record CastRequestDto(Guid PersonId, CastRole Role);
