namespace IMDB.Application.Features.Comments.Queries.GetCommentsByIds;
public record GetCommentsByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<CommentDto>>;
