using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPersonById;
public record GetPersonByIdQuery : IRequest<Person?>
{
}
