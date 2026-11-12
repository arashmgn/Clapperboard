using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
public record GetCommentsPaginatedQuery : IRequest<(List<Comment> Items, int TotalCount)>
{
}
