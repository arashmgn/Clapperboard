using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeople;
public record GetPeopleQuery : IRequest<List<Person>>
{
}
