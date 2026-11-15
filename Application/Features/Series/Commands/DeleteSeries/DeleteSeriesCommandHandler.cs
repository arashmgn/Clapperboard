using IMDB.Application.Common.Exceptions;

namespace IMDB.Application.Features.Series.Commands.DeleteSeries;
public class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.Series
            .Include(s => s.Seasons)
            .ThenInclude(s => s.Episodes)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Series {request.Id} was not found.");

        // Seasons and episodes use DeleteBehavior.Restrict, so children must be removed before the root.
        var seasons = series.Seasons.ToList();
        _context.Episodes.RemoveRange(seasons.SelectMany(s => s.Episodes));
        _context.Seasons.RemoveRange(seasons);
        _context.Series.Remove(series);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
