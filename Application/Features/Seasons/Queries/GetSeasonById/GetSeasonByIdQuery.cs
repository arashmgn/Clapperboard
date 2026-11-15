namespace IMDB.Application.Features.Seasons.Queries.GetSeasonById;
public record GetSeasonByIdQuery(Guid Id) : IRequest<SeasonDto?>;
