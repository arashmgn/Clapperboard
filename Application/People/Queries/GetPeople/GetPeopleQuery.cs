using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Queries.GetPeople;

public record GetPeopleQuery : IRequest<List<Person>>;
