using IMDB.Application.Common.Exceptions;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Commands.CreateCast;
public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        var personExists = await _context.People
            .AnyAsync(p => p.Id == request.PersonId, cancellationToken);
        if (!personExists)
            throw new ApplicationsExceptions.NotFoundException($"Person {request.PersonId} was not found.");

        var mediaExists = await _context.Movies.AnyAsync(m => m.Id == request.MediaId, cancellationToken)
            || await _context.Series.AnyAsync(s => s.Id == request.MediaId, cancellationToken);
        if (!mediaExists)
            throw new ApplicationsExceptions.NotFoundException($"Media {request.MediaId} was not found.");

        var cast = CastEntity.Create(request.MediaId, request.PersonId, request.Role);
        _context.Casts.Add(cast);
        await _context.SaveChangesAsync(cancellationToken);

        return cast.Id;
    }
}
