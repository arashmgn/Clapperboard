using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMovies;

public record GetMoviesQuery : IRequest<List<Movie>>;
