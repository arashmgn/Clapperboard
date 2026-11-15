namespace IMDB.Application.Features.People.Queries.GetPeopleByIds;
public record GetPeopleByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<PersonDto>>;
