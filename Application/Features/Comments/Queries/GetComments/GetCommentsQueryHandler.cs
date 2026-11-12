using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetComments;
public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<Comment>>
{
}
