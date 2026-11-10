using api.Enums;
using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Movies.Commands.DeleteMovie;
public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
{
}
