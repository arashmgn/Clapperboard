using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRatesByIds;
public class GetRatesByIdsQueryHandler : IRequestHandler<GetRatesByIdsQuery, List<Rate>>
{
}
