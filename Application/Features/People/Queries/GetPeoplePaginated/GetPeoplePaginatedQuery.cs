using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public record GetPeoplePaginatedQuery : IRequest<(List<Person> Items, int TotalCount)>
{
}
