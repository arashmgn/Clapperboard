using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeople;
public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<Person>>
{
}
