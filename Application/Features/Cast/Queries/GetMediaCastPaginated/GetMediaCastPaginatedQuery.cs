namespace IMDB.Application.Features.Cast.Queries.GetMediaCastPaginated;
public record GetMediaCastPaginatedQuery(Guid MediaId, int Page, int PageSize) : IRequest<(List<CastDto> Items, int TotalCount)>;
