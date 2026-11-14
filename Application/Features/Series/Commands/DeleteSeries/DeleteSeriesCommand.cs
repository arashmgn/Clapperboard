namespace IMDB.Application.Features.Series.Commands.DeleteSeries;
public record DeleteSeriesCommand(Guid Id) : IRequest<bool>;
