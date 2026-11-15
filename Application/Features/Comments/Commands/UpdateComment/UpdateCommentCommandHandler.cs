using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Comments.Commands.UpdateComment;
public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public UpdateCommentCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Comment {request.Id} was not found.");

        comment.Edit(userId, request.Text);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
