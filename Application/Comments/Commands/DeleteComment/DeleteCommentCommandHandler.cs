using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (comment is null)
            return false;

        if (comment.UserId != request.UserId)
            throw new UnauthorizedAccessException("Only the author can delete this comment.");

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
