using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
    }
}
