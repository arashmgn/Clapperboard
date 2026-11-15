namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public record GetMoviesPaginatedQuery(int Page, int PageSize) : IRequest<(List<MovieDto> Items, int TotalCount)>;
