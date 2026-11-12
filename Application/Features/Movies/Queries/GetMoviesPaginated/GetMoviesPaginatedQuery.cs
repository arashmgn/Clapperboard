using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public record GetMoviesPaginatedQuery : IRequest<(List<Movie> Items, int TotalCount)>
{
}
