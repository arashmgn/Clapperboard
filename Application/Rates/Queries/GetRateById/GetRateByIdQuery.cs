using IMDB.Domain.Entities;
using MediatR;

namespace IMDB.Application.Rates.Queries.GetRateById;

public record GetRateByIdQuery(int Id) : IRequest<Rate?>;
