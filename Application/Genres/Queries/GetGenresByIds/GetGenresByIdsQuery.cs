using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenresByIds
{
    public record GetGenresByIdsQuery : IRequest<List<Genre>>
    {
    }
}
