using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public record GetMoviesPaginatedQuery(int Page, int PageSize) : IRequest<(List<Movie> Items, int TotalCount)>;
