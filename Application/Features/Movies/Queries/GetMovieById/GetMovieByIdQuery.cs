namespace IMDB.Application.Features.Movies.Queries.GetMovieById;
public record GetMovieByIdQuery(Guid Id) : IRequest<MovieDto?>;
