using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenresPaginated
{
    public class GetGenresPaginatedQueryHandler : IRequestHandler<GetGenresPaginatedQuery, (List<Genre> Items, int TotalCount)>
    {
    }
}
