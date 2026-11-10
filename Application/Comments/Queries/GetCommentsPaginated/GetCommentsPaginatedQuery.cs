using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetCommentsPaginated;
public record GetCommentsPaginatedQuery : IRequest<(List<Comment> Items, int TotalCount)>
{
}
