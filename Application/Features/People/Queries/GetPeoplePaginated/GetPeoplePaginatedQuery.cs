using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public record GetPeoplePaginatedQuery(int Page, int PageSize) : IRequest<(List<Person> Items, int TotalCount)>;
