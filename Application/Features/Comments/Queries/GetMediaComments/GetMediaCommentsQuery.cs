namespace IMDB.Application.Features.Comments.Queries.GetMediaComments;
public record GetMediaCommentsQuery(Guid MediaId) : IRequest<List<CommentDto>>;
