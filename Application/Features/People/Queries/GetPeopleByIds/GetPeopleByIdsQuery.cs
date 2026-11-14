using IMDB.Domain.Entities;

namespace IMDB.Application.Features.People.Queries.GetPeopleByIds;
public record GetPeopleByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<Person>>;
