using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenresPaginated
{
    public class GetGenresPaginatedQueryHandler : IRequestHandler<GetGenresPaginatedQuery, (List<Genre> Items, int TotalCount)>
    {
    }
}
