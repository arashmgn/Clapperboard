using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
}
