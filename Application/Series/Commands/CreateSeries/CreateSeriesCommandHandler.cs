using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeriesEntity = IMDB.Domain.Entities.Series;

namespace IMDB.Application.Series.Commands.CreateSeries;
public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, int>
{
}
