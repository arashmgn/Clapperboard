using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Queries.GetMediaComments;
public class GetMediaCommentsQueryHandler : IRequestHandler<GetMediaCommentsQuery, List<Comment>>
{
}
