using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetMediaRates;
public class GetMediaRatesQueryHandler : IRequestHandler<GetMediaRatesQuery, List<Rate>>
{
}
