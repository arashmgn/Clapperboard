namespace IMDB.Application.Features.Cast.Queries.GetCastPaginated;
public record GetCastPaginatedQuery(int Page, int PageSize) : IRequest<(List<CastDto> Items, int TotalCount)>;
