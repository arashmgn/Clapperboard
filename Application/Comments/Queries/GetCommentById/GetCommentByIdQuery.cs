using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetCommentById;

public record GetCommentByIdQuery(int Id) : IRequest<Comment?>;
