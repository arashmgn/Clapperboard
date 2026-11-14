namespace IMDB.Application.Features.Comments.Commands.UpdateComment;
public record UpdateCommentCommand(Guid Id, string Text) : IRequest<bool>;
