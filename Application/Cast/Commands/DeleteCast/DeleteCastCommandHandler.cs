using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Cast.Commands.DeleteCast;

public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCastCommand request, CancellationToken cancellationToken)
    {
        var cast = await _context.Cast.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (cast is null)
            return false;

        _context.Cast.Remove(cast);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
