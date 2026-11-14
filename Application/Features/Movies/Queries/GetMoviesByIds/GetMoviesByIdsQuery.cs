using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMoviesByIds;
public record GetMoviesByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<Movie>>;
