namespace IMDB.Application.Features.Rates.Queries.GetRateById;
public record GetRateByIdQuery(Guid Id) : IRequest<RateDto?>;
