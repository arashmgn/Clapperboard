using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Commands.UpdateComment;
public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
{
}
