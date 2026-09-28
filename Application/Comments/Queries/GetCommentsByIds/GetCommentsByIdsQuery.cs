using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetCommentsByIds;

public record GetCommentsByIdsQuery(IEnumerable<int> Ids) : IRequest<List<Comment>>;
