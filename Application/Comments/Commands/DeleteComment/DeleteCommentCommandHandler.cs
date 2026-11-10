using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Commands.DeleteComment;
public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
}
