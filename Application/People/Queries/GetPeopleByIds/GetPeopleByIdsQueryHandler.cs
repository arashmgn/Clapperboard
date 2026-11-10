using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Queries.GetPeopleByIds;
public class GetPeopleByIdsQueryHandler : IRequestHandler<GetPeopleByIdsQuery, List<Person>>
{
}
