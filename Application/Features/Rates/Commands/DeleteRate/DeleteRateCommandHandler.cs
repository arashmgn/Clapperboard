using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Rates.Commands.DeleteRate;
public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public DeleteRateCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        var rate = await _context.Rates
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Rate {request.Id} was not found.");

        rate.EnsureOwnedBy(userId);

        _context.Rates.Remove(rate);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
