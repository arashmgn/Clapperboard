using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Cast.Commands.DeleteCast;
public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCastCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Casts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null)
        {
            throw new ApplicationsExceptions.NotFoundException($"Cast {request.Id} was not found.");
        }
        _context.Casts.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
