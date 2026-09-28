using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Movies.Queries.GetMovieById;

public record GetMovieByIdQuery(int Id) : IRequest<Movie?>;
