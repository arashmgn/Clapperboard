using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;
using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Comments.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public CreateCommentCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        if (!await _context.MediaExistsAsync(request.MediaId, cancellationToken))
            throw new ApplicationsExceptions.NotFoundException($"Media {request.MediaId} was not found.");

        var comment = Comment.Create(request.MediaId, userId, request.Text);
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return comment.Id;
    }
}
