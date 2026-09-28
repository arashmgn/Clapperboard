using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (comment is null)
            return false;

        if (comment.UserId != request.UserId)
            throw new UnauthorizedAccessException("Only the author can edit this comment.");

        comment.Edit(request.Text);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
