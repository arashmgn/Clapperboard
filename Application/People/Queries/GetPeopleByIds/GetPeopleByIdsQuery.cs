using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Queries.GetPeopleByIds;
public record GetPeopleByIdsQuery : IRequest<List<Person>>
{
}
