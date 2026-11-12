using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMovies;
public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Movie>>
{
}
