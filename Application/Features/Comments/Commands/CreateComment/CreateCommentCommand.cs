namespace IMDB.Application.Features.Comments.Commands.CreateComment;
public record CreateCommentCommand(Guid MediaId, string Text) : IRequest<Guid>;
