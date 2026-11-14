using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Queries.GetCommentById;
public record GetCommentByIdQuery(Guid Id) : IRequest<Comment?>;
