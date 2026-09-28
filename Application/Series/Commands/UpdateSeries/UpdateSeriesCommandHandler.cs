using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Series.Commands.UpdateSeries;

public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.Series.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (series is null)
            return false;

        var info = new MediaInfo(request.ImdbId, request.Title, request.Description, request.PosterUrl, request.ReleaseDate);
        series.Update(info);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
