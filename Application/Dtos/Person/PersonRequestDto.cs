namespace IMDB.Application.Dtos;

public sealed record PersonRequestDto(
    string ImdbId,
    string FullName,
    DateTime BirthDate,
    string Bio,
    string PhotoUrl);
