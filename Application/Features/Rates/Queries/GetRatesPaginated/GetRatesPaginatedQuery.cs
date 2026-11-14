using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
public record GetRatesPaginatedQuery(int Page, int PageSize) : IRequest<(List<Rate> Items, int TotalCount)>;
