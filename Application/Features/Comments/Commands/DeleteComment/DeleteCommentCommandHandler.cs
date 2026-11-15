using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Comments.Commands.DeleteComment;
public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public DeleteCommentCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Comment {request.Id} was not found.");

        comment.EnsureOwnedBy(userId);
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
