using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
public class GetRatesPaginatedQueryHandler : IRequestHandler<GetRatesPaginatedQuery, (List<Rate> Items, int TotalCount)>
{
}
