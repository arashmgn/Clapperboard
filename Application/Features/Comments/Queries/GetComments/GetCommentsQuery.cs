using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetComments;
public record GetCommentsQuery : IRequest<List<Comment>>;
