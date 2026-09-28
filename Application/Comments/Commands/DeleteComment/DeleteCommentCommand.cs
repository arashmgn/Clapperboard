using MediatR;

namespace IMDB.Application.Comments.Commands.DeleteComment;

public record DeleteCommentCommand(int Id, string UserId) : IRequest<bool>;
