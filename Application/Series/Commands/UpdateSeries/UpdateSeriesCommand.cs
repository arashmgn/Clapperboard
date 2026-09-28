using MediatR;

namespace IMDB.Application.Series.Commands.UpdateSeries;

public record UpdateSeriesCommand(
    int Id,
    string ImdbId,
    string Title,
    string Description,
    string PosterUrl,
    DateTime ReleaseDate) : IRequest<bool>;
