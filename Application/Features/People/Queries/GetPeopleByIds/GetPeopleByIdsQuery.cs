using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeopleByIds;
public record GetPeopleByIdsQuery : IRequest<List<Person>>
{
}
