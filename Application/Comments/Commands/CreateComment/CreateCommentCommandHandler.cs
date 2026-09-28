using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Comments.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.TargetExistsAsync(request.TargetType, request.TargetId, cancellationToken))
            throw new KeyNotFoundException($"{request.TargetType} {request.TargetId} was not found.");

        var comment = Comment.Create(request.Text, request.UserId, request.TargetType, request.TargetId);

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return comment.Id;
    }
}
