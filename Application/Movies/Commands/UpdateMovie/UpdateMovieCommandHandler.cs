using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.UpdateMovie;
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
{
}
