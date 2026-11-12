using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCast;
public record GetMediaCastQuery : IRequest<List<CastEntity>>
{
}
