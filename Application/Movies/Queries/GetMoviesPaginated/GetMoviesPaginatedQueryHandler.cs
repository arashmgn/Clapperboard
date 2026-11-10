using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMoviesPaginated;
public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, (List<Movie> Items, int TotalCount)>
{
}
