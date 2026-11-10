using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Queries.GetPeoplePaginated;
public record GetPeoplePaginatedQuery : IRequest<(List<Person> Items, int TotalCount)>
{
}
