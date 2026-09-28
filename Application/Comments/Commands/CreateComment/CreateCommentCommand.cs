using api.Enums;
using MediatR;

namespace IMDB.Application.Comments.Commands.CreateComment;

public record CreateCommentCommand(
    string UserId,
    ReviewTargetType TargetType,
    int TargetId,
    string Text) : IRequest<int>;
