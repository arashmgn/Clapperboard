using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Commands.CreatePerson;
public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
}
