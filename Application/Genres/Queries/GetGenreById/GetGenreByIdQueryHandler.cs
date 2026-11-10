using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre?>
    {
    }
}
