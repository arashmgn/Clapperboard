using IMDB.Application.Common.Interfaces;
using IMDB.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Series.Commands.UpdateSeries;
public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand, bool>
{
}
