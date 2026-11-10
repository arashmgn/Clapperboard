using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetComments;
public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<Comment>>
{
}
