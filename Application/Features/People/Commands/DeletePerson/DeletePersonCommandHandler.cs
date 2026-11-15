using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.People.Commands.DeletePerson;
public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _context.People
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Person {request.Id} was not found.");

        _context.People.Remove(person);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
