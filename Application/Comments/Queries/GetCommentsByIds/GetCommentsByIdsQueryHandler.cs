using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetCommentsByIds;
public class GetCommentsByIdsQueryHandler : IRequestHandler<GetCommentsByIdsQuery, List<Comment>>
{
}
