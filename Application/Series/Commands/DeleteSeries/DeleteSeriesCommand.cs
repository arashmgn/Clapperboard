using MediatR;

namespace IMDB.Application.Series.Commands.DeleteSeries;
public record DeleteSeriesCommand : IRequest<bool>
{
}
