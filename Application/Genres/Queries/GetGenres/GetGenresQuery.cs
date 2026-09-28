using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenres
{
    public record GetGenresQuery : IRequest<List<Genre>>;
}
