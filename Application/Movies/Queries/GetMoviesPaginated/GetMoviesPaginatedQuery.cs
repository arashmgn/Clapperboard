using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMoviesPaginated;
public record GetMoviesPaginatedQuery : IRequest<(List<Movie> Items, int TotalCount)>
{
}
