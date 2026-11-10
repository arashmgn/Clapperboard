using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
    {
    }
}
