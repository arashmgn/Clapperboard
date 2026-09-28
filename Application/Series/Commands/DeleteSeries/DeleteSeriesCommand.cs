using MediatR;

namespace IMDB.Application.Series.Commands.DeleteSeries;

public record DeleteSeriesCommand(int Id) : IRequest<bool>;
