using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Genres.Commands.CreateGenre;
public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
{
}
