namespace IMDB.Application.Features.Series.Queries.GetSeriesPaginated;
public record GetSeriesPaginatedQuery(int Page, int PageSize) : IRequest<(List<SeriesDto> Items, int TotalCount)>;
