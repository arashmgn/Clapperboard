using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetCommentById;
public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment?>
{
}
