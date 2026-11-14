using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
public record GetCommentsPaginatedQuery(int Page, int PageSize) : IRequest<(List<Comment> Items, int TotalCount)>;
