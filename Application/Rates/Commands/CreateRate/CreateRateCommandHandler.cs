using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Commands.CreateRate;

public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.TargetExistsAsync(request.TargetType, request.TargetId, cancellationToken))
            throw new KeyNotFoundException($"{request.TargetType} {request.TargetId} was not found.");

        var alreadyRated = await _context.Rates.AnyAsync(
            x => x.UserId == request.UserId && x.TargetType == request.TargetType && x.TargetId == request.TargetId,
            cancellationToken);
        if (alreadyRated)
            throw new InvalidOperationException("You have already rated this item.");

        var rate = Rate.Create(request.UserId, request.TargetType, request.TargetId, request.Score);

        _context.Rates.Add(rate);
        await _context.SaveChangesAsync(cancellationToken);

        return rate.Id;
    }
}
