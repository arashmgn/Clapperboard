using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
public record GetRatesPaginatedQuery : IRequest<(List<Rate> Items, int TotalCount)>
{
}
