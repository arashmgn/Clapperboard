namespace IMDB.Application.Features.Cast.Queries.GetMediaCast;
public record GetMediaCastQuery(Guid MediaId) : IRequest<List<CastDto>>;
