using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.DeleteRate;

public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteRateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
    {
        var rate = await _context.Rates.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (rate is null)
            return false;

        if (rate.UserId != request.UserId)
            throw new UnauthorizedAccessException("Only the owner can delete this rate.");

        _context.Rates.Remove(rate);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
