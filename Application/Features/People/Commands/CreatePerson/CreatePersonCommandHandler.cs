using IMDB.Domain.Common;
using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Features.People.Commands.CreatePerson;
public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.People
            .AnyAsync(p => p.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A person with IMDB ID {request.ImdbId} already exists.");

        var person = Person.Create(request.ImdbId, request.FullName, request.BirthDate, request.Bio, request.PhotoUrl);
        _context.People.Add(person);
        await _context.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}
