using MediatR;

namespace IMDB.Application.Comments.Commands.UpdateComment;

// UserId is the current user; only the author may edit the comment.
public record UpdateCommentCommand(int Id, string UserId, string Text) : IRequest<bool>;
