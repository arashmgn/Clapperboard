using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public class GetPeoplePaginatedQueryHandler : IRequestHandler<GetPeoplePaginatedQuery, (List<Person> Items, int TotalCount)>
{
}
