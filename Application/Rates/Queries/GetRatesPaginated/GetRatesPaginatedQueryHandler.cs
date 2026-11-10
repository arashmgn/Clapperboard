using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRatesPaginated;
public class GetRatesPaginatedQueryHandler : IRequestHandler<GetRatesPaginatedQuery, (List<Rate> Items, int TotalCount)>
{
}
