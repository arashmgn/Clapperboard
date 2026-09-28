using api.Enums;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Queries.GetMediaComments;

public record GetMediaCommentsQuery(ReviewTargetType TargetType, int TargetId) : IRequest<List<Comment>>;
