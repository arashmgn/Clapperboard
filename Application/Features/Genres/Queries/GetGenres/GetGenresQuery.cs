using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenres;
public record GetGenresQuery : IRequest<List<Genre>>;
