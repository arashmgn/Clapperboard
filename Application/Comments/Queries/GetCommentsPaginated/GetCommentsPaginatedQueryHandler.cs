using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetCommentsPaginated;
public class GetCommentsPaginatedQueryHandler : IRequestHandler<GetCommentsPaginatedQuery, (List<Comment> Items, int TotalCount)>
{
}
