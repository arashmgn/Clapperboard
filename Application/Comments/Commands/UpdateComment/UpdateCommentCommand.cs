using MediatR;

namespace IMDB.Application.Comments.Commands.UpdateComment;

public record UpdateCommentCommand(int Id, string UserId, string Text) : IRequest<bool>;
