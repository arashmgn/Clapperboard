namespace IMDB.Application.Features.People.Queries.GetPeoplePaginated;
public record GetPeoplePaginatedQuery(int Page, int PageSize) : IRequest<(List<PersonDto> Items, int TotalCount)>;
