using MediatR;

namespace IMDB.Application.Series.Commands.CreateSeries;
public record CreateSeriesCommand : IRequest<int>
{
}
