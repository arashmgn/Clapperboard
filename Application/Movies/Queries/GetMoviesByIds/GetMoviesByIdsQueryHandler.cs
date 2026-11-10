using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMoviesByIds;
public class GetMoviesByIdsQueryHandler : IRequestHandler<GetMoviesByIdsQuery, List<Movie>>
{
}
