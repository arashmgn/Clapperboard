using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPeoplePaginated;
public class GetPeoplePaginatedQueryHandler : IRequestHandler<GetPeoplePaginatedQuery, (List<Person> Items, int TotalCount)>
{
}
