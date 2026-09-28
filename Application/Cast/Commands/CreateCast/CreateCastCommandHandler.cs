using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Cast.Commands.CreateCast;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.TargetExistsAsync(request.TargetType, request.TargetId, cancellationToken))
            throw new KeyNotFoundException($"{request.TargetType} {request.TargetId} was not found.");

        if (!await _context.People.AnyAsync(p => p.Id == request.PersonId, cancellationToken))
            throw new KeyNotFoundException($"Person {request.PersonId} was not found.");

        var cast = CastEntity.Create(request.TargetType, request.TargetId, request.PersonId, request.Role);

        _context.Cast.Add(cast);
        await _context.SaveChangesAsync(cancellationToken);

        return cast.Id;
    }
}
