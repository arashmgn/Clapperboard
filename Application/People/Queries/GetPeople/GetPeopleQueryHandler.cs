using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPeople;
public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<Person>>
{
}
