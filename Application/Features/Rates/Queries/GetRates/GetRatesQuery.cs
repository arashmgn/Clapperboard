using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRates;
public record GetRatesQuery : IRequest<List<Rate>>;
