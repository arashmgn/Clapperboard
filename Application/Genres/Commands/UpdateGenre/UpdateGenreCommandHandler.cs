using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Commands.UpdateGenre;
public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, bool>
{
}
