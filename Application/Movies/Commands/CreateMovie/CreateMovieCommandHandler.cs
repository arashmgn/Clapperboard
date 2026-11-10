using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.CreateMovie;
public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
}
