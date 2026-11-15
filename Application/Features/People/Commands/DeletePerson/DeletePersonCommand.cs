namespace IMDB.Application.Features.People.Commands.DeletePerson;
public record DeletePersonCommand(Guid Id) : IRequest<bool>;
