using IMDB.Application.Common.Exceptions;
using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Features.People.Commands.UpdatePerson;
public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _context.People
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Person {request.Id} was not found.");

        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.People
            .AnyAsync(p => p.Id != request.Id && p.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A person with IMDB ID {request.ImdbId} already exists.");

        person.Update(request.ImdbId, request.FullName, request.BirthDate, request.Bio, request.PhotoUrl);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
