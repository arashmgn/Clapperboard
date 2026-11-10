using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetCommentById;
public record GetCommentByIdQuery : IRequest<Comment?>
{
}
