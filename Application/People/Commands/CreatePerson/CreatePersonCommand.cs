using MediatR;

namespace IMDB.Application.People.Commands.CreatePerson;

public record CreatePersonCommand(
    string ImdbId,
    string FullName,
    DateTime BirthDate,
    string Bio,
    string PhotoUrl) : IRequest<int>;
