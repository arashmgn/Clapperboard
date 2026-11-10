using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenresPaginated
{
    public record GetGenresPaginatedQuery : IRequest<(List<Genre> Items, int TotalCount)>
    {
    }
}
