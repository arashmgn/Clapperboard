using IMDB.Domain.Entities;
using IMDB.Domain.ValueObjects;

namespace IMDB.Application.Mappings;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ImdbId, string>().ConvertUsing(v => v.Value);
        CreateMap<Rating, double>().ConvertUsing(v => v.Value);

        CreateMap<Genre, GenreDto>();
        CreateMap<Person, PersonDto>();
        CreateMap<Movie, MovieDto>();
        CreateMap<Series, SeriesDto>();
        CreateMap<Episode, EpisodeDto>();

        CreateMap<Season, SeasonDto>()
            .ForMember(d => d.Episodes, o => o.MapFrom(s => s.Episodes.OrderBy(e => e.EpisodeNumber)));

        CreateMap<Cast, CastDto>();

        CreateMap<Comment, CommentDto>()
            .ForCtorParam(nameof(CommentDto.UserName), o => o.MapFrom(_ => (string?)null));

        CreateMap<Rate, RateDto>()
            .ForCtorParam(nameof(RateDto.UserName), o => o.MapFrom(_ => (string?)null));
    }
}
