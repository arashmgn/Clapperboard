using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRates;
public class GetRatesQueryHandler : IRequestHandler<GetRatesQuery, List<Rate>>
{
}
