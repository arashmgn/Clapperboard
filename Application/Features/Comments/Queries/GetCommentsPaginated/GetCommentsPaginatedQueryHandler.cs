using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
public class GetCommentsPaginatedQueryHandler : IRequestHandler<GetCommentsPaginatedQuery, (List<Comment> Items, int TotalCount)>
{
}
