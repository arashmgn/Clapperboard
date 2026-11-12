using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetMediaRates;
public record GetMediaRatesQuery : IRequest<List<Rate>>
{
}
