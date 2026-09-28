using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMoviesByIds;

public record GetMoviesByIdsQuery(IEnumerable<int> Ids) : IRequest<List<Movie>>;
