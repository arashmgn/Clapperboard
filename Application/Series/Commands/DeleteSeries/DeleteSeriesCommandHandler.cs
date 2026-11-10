using api.Enums;
using IMDB.Application.Common.Extensions;
using IMDB.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Series.Commands.DeleteSeries;
public class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand, bool>
{
}
