using IMDB.Domain.Enums;

namespace IMDB.Application.Dtos;

public sealed record CastDto(Guid Id, Guid MediaId, Guid PersonId, CastRole Role, PersonDto? Person);
