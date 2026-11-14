using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetMediaRates;
public record GetMediaRatesQuery(Guid MediaId) : IRequest<List<Rate>>;
