using IMDB.Application.Common.Interfaces;
using IMDB.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Application.Rates.Queries.GetRateById;
public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, Rate?>
{
}
