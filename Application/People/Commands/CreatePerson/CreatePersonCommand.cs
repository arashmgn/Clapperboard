using MediatR;

namespace IMDB.Application.People.Commands.CreatePerson;
public record CreatePersonCommand : IRequest<int>
{
}
