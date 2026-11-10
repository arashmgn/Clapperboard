using MediatR;

namespace IMDB.Application.Comments.Commands.DeleteComment;
public record DeleteCommentCommand : IRequest<bool>
{
}
