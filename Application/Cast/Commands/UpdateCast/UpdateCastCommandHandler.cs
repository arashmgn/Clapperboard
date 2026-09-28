using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Cast.Commands.UpdateCast;

public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        var cast = await _context.Cast.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (cast is null)
            return false;

        cast.ChangeRole(request.Role);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
