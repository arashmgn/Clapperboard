using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPersonById;
public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person?>
{
}
