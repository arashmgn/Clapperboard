using MediatR;

namespace IMDB.Application.People.Commands.DeletePerson;

public record DeletePersonCommand(int Id) : IRequest<bool>;
