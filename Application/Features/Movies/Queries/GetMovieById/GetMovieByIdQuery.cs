using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Movies.Queries.GetMovieById;
public record GetMovieByIdQuery(Guid Id) : IRequest<Movie?>;
