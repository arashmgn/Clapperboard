using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.People.Commands.CreatePerson;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = Person.Create(request.ImdbId, request.FullName, request.BirthDate, request.Bio, request.PhotoUrl);

        _context.People.Add(person);
        await _context.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}
