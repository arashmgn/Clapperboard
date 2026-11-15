using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;
using IMDB.Domain.Common;
using IMDB.Domain.Entities;

namespace IMDB.Application.Features.Rates.Commands.CreateRate;
public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;

    public CreateRateCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetRequiredUserId();

        if (!await _context.MediaExistsAsync(request.MediaId, cancellationToken))
            throw new ApplicationsExceptions.NotFoundException($"Media {request.MediaId} was not found.");

        var alreadyRated = await _context.Rates
            .AnyAsync(r => r.MediaId == request.MediaId && r.UserId == userId, cancellationToken);
        if (alreadyRated)
            throw new DomainException("You have already rated this media.");

        var rate = Rate.Create(request.MediaId, userId, request.Score);
        _context.Rates.Add(rate);
        await _context.SaveChangesAsync(cancellationToken);

        return rate.Id;
    }
}
