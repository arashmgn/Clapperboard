using CastEntity = IMDB.Domain.Entities.Cast;

namespace IMDB.Application.Features.Cast.Queries.GetMediaCast;
public class GetMediaCastQueryHandler : IRequestHandler<GetMediaCastQuery, List<CastEntity>>
{
}
