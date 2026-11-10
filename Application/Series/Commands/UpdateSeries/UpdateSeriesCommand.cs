using MediatR;

namespace IMDB.Application.Series.Commands.UpdateSeries;
public record UpdateSeriesCommand : IRequest<bool>
{
}
