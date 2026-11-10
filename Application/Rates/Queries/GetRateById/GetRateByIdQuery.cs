using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRateById;
public record GetRateByIdQuery : IRequest<Rate?>
{
}
