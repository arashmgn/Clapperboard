namespace IMDB.Application.Dtos;

public sealed record PersonDto(
    Guid Id,
    string ImdbId,
    string FullName,
    DateTime BirthDate,
    string Bio,
    string PhotoUrl);
