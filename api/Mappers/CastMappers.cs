using IMDB.Application.Dtos;
using CastEntity = IMDB.Domain.Entities.Cast;

namespace api.Mappers;
public static class CastMappers
{
    public static CastDto ToDto(this CastEntity cast)
    {
        return new CastDto(cast.Id, cast.MediaId, cast.PersonId, cast.Role, null);
    }
}
