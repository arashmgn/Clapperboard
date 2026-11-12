using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenresPaginated
{
    public record GetGenresPaginatedQuery : IRequest<(List<Genre> Items, int TotalCount)>
    {
    }
}
