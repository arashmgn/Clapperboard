using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Commands.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (person is null)
            return false;

        // Cast rows of this person have a real foreign key with cascade, so the database removes them.
        _context.People.Remove(person);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
