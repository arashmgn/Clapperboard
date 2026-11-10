using api.Enums;
using MediatR;

namespace IMDB.Application.Comments.Commands.CreateComment;
public record CreateCommentCommand : IRequest<int>
{
}
