using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Commands.UpdatePerson;
public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
{
}
