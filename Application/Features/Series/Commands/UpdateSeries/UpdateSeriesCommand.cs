namespace IMDB.Application.Features.Series.Commands.UpdateSeries;
public record UpdateSeriesCommand(
    Guid Id,
    string ImdbId,
    string Title,
    DateTime ReleaseDate,
    string Description,
    string PosterUrl,
    double Rate,
    IReadOnlyList<Guid> GenreIds) : IRequest<bool>;
