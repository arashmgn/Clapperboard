using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMovies;
public record GetMoviesQuery : IRequest<List<Movie>>
{
}
