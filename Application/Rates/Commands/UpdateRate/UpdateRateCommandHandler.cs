using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.UpdateRate;

public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateRateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
    {
        var rate = await _context.Rates.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (rate is null)
            return false;

        if (rate.UserId != request.UserId)
            throw new UnauthorizedAccessException("Only the owner can change this rate.");

        rate.ChangeScore(request.Score);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
