using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPersonById;
public record GetPersonByIdQuery(Guid Id) : IRequest<Person?>;
