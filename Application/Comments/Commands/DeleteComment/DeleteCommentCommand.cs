using MediatR;

namespace IMDB.Application.Comments.Commands.DeleteComment;

// UserId is the current user; only the author may delete the comment.
public record DeleteCommentCommand(int Id, string UserId) : IRequest<bool>;
