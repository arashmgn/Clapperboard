using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenresByIds
{
    public record GetGenresByIdsQuery : IRequest<List<Genre>>
    {
    }
}
