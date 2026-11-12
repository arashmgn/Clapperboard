using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentsByIds;
public record GetCommentsByIdsQuery : IRequest<List<Comment>>
{
}
