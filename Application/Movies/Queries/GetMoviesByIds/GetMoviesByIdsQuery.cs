using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMoviesByIds;
public record GetMoviesByIdsQuery : IRequest<List<Movie>>
{
}
