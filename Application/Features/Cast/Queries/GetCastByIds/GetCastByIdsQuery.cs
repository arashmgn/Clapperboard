namespace IMDB.Application.Features.Cast.Queries.GetCastByIds;
public record GetCastByIdsQuery(IReadOnlyList<Guid> Ids) : IRequest<List<CastDto>>;
