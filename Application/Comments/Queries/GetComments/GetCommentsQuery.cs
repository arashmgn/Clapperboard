using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetComments;
public record GetCommentsQuery : IRequest<List<Comment>>
{
}
