namespace IMDB.Application.Features.Genres.Queries.GetGenresPaginated;
public record GetGenresPaginatedQuery(int Page, int PageSize) : IRequest<(List<GenreDto> Items, int TotalCount)>;
