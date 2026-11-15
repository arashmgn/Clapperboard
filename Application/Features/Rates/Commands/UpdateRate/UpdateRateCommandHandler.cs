using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Rates.Commands.UpdateRate;
public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public UpdateRateCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        var rate = await _context.Rates
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Rate {request.Id} was not found.");

        rate.ChangeScore(userId, request.Score);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
