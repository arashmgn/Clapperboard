using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetCommentsPaginated;

public record GetCommentsPaginatedQuery(int Page, int PageSize) : IRequest<(List<Comment> Items, int TotalCount)>;
