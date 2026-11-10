using MediatR;

namespace IMDB.Application.People.Commands.UpdatePerson;
public record UpdatePersonCommand : IRequest<bool>
{
}
