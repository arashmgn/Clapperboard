using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenresByIds
{
    public class GetGenresByIdsQueryHandler : IRequestHandler<GetGenresByIdsQuery, List<Genre>>
    {
    }
}
