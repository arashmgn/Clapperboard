using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Queries.GetPersonById;

public record GetPersonByIdQuery(int Id) : IRequest<Person?>;
