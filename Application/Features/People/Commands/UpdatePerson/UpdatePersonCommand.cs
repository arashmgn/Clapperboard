namespace IMDB.Application.Features.People.Commands.UpdatePerson;
public record UpdatePersonCommand(
    Guid Id,
    string ImdbId,
    string FullName,
    DateTime BirthDate,
    string Bio,
    string PhotoUrl) : IRequest<bool>;
