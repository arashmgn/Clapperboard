using MediatR;

namespace IMDB.Application.People.Commands.UpdatePerson;

public record UpdatePersonCommand(
    int Id,
    string FullName,
    DateTime BirthDate,
    string Bio,
    string PhotoUrl) : IRequest<bool>;
