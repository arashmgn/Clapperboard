using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
    {
    }
}
