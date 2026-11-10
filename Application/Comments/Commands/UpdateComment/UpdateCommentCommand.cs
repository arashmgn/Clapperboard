using MediatR;

namespace IMDB.Application.Comments.Commands.UpdateComment;
public record UpdateCommentCommand : IRequest<bool>
{
}
