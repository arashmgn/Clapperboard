using api.Enums;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetMediaRates;
public record GetMediaRatesQuery : IRequest<List<Rate>>
{
}
