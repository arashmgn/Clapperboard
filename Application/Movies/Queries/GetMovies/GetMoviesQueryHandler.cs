using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMovies;
public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Movie>>
{
}
