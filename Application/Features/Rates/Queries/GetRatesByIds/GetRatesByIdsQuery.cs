using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRatesByIds;
public record GetRatesByIdsQuery : IRequest<List<Rate>>
{
}
