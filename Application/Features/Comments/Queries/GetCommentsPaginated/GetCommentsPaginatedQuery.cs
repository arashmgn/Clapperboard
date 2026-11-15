namespace IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
public record GetCommentsPaginatedQuery(int Page, int PageSize) : IRequest<(List<CommentDto> Items, int TotalCount)>;
