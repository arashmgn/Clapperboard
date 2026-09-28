using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Queries.GetPeopleByIds;

public record GetPeopleByIdsQuery(IEnumerable<int> Ids) : IRequest<List<Person>>;
