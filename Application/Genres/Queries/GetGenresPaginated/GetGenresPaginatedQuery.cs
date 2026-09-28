using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenresPaginated
{
    public record GetGenresPaginatedQuery(int Page, int PageSize) : IRequest<(List<Genre> Items, int TotalCount)>;
}
