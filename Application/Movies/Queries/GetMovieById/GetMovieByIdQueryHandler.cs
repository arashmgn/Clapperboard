using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Queries.GetMovieById;
public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie?>
{
}
