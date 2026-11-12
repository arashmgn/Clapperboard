using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesPaginated;
public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, (List<Movie> Items, int TotalCount)>
{
}
