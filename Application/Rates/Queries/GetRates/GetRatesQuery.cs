using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRates;
public record GetRatesQuery : IRequest<List<Rate>>
{
}
