using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetMediaComments;
public record GetMediaCommentsQuery : IRequest<List<Comment>>
{
}
