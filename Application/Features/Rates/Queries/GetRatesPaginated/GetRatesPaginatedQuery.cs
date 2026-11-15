namespace IMDB.Application.Features.Rates.Queries.GetRatesPaginated;
public record GetRatesPaginatedQuery(int Page, int PageSize) : IRequest<(List<RateDto> Items, int TotalCount)>;
