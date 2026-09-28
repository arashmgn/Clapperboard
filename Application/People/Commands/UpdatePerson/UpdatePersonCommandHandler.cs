using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.People.Commands.UpdatePerson;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (person is null)
            return false;

        person.Update(request.FullName, request.BirthDate, request.Bio, request.PhotoUrl);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
