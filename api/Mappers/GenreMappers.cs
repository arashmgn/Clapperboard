using IMDB.Domain.Entities;
using API.Dtos;

namespace api.Mappers;

public static class GenreMappers
{
    public static GenreDto ToGenreDto(this Genre genreModel)
    {
        return new GenreDto
        {
            Id = genreModel.Id,
            Title = genreModel.Title,
        };
    }
}
