using IMDB.Application.Common.Exceptions;
using IMDB.Application.Common.Extensions;
using IMDB.Domain.Common;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Features.Series.Commands.UpdateSeries;
public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
            ?? throw new ApplicationsExceptions.NotFoundException($"Series {request.Id} was not found.");

        var imdbId = ImdbId.From(request.ImdbId);

        var imdbIdTaken = await _context.Series
            .AnyAsync(s => s.Id != request.Id && s.ImdbId == imdbId, cancellationToken);
        if (imdbIdTaken)
            throw new DomainException($"A series with IMDB ID {request.ImdbId} already exists.");

        var genres = await _context.GetGenresAsync(request.GenreIds, cancellationToken);

        series.Update(
            request.ImdbId, request.Title, request.ReleaseDate, request.Description,
            request.PosterUrl, request.Rate, genres);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
