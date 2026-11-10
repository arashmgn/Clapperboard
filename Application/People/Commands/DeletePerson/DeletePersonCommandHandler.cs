using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Commands.DeletePerson;
public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
}
