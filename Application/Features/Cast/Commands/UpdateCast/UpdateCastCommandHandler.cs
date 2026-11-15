using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Cast.Commands.UpdateCast;

public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        var cast = await _context.Casts
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (cast is null)
            throw new ApplicationsExceptions.NotFoundException($"Cast {request.Id} was not found.");
        var personExists = await _context.People.AnyAsync(p => p.Id == request.PersonId, cancellationToken);
        if (!personExists)
            throw new ApplicationsExceptions.NotFoundException($"Person {request.PersonId} was not found.");
        var mediaExists = await _context.Movies.AnyAsync(m => m.Id == request.MediaId, cancellationToken)
            || await _context.Series.AnyAsync(s => s.Id == request.MediaId, cancellationToken);
        if(!mediaExists)
            throw new ApplicationsExceptions.NotFoundException($"Media {request.MediaId} was not found.");
        cast.Update(request.MediaId, request.PersonId, request.Role);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
