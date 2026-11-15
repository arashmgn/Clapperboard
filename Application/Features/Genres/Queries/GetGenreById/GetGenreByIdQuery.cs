namespace IMDB.Application.Features.Genres.Queries.GetGenreById;
public record GetGenreByIdQuery(Guid Id) : IRequest<GenreDto?>;
