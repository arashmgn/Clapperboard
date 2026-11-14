using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRatesByIds;
public record GetRatesByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<Rate>>;
