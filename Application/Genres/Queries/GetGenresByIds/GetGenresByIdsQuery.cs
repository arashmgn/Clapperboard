using MediatR;
using IMDB.Domain.Entities;

namespace IMDB.Application.Genres.Queries.GetGenresByIds
{
    public record GetGenresByIdsQuery(IEnumerable<int> Ids) : IRequest<List<Genre>>;
}
