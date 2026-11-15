namespace IMDB.Application.Features.People.Queries.GetPersonById;
public record GetPersonByIdQuery(Guid Id) : IRequest<PersonDto?>;
