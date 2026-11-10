using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenreById
{
    public record GetGenreByIdQuery : IRequest<Genre?>
    {
    }
}
