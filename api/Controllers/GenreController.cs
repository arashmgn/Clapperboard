using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using API.Dtos;
using api.Mappers;
using api.Helpers;
using IMDB.Application.Genres.Commands.CreateGenre;
using IMDB.Application.Genres.Commands.DeleteGenre;
using IMDB.Application.Genres.Commands.UpdateGenre;
using IMDB.Application.Genres.Queries.GetGenreById;
using IMDB.Application.Genres.Queries.GetGenres;
using IMDB.Application.Genres.Queries.GetGenresPaginated;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Get Genres

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int? page, [FromQuery] int? pageSize)
    {
        try
        {
            if (page.HasValue && pageSize.HasValue)
            {
                var (genres, totalCount) = await _mediator.Send(new GetGenresPaginatedQuery(page.Value, pageSize.Value));
                var genreDto = genres.Select(g => g.ToGenreDto()).ToList();

                return ApiResponse.Success(new
                {
                    TotalCount = totalCount,
                    Page = page.Value,
                    PageSize = pageSize.Value,
                    Data = genreDto
                }, "Paginated genres retrieved successfully");
            }
            else
            {
                var genres = await _mediator.Send(new GetGenresQuery());
                var genreDto = genres.Select(g => g.ToGenreDto()).ToList();
                return ApiResponse.Success(genreDto, "Genres retrieved successfully");
            }
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve genres", 500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {
        try
        {
            var genre = await _mediator.Send(new GetGenreByIdQuery(id));
            if (genre == null)
                return ApiResponse.NotFound("Genre not found");

            return ApiResponse.Success(genre.ToGenreDto(), "Genre retrieved successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve genre", 500);
        }
    }

    #endregion

    #region CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreRequestDto genreDto)
    {
        try
        {
            var id = await _mediator.Send(new CreateGenreCommand(genreDto.Title));

            return ApiResponse.Success(new GenreDto { Id = id, Title = genreDto.Title }, "Genre created successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to create genre", 500);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GenreRequestDto genreDto)
    {
        try
        {
            var isUpdated = await _mediator.Send(new UpdateGenreCommand(id, genreDto.Title));
            if (!isUpdated)
                return ApiResponse.NotFound("Genre not found");

            return ApiResponse.Success(new GenreDto { Id = id, Title = genreDto.Title }, "Genre updated successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to update genre", 500);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var isRemoved = await _mediator.Send(new DeleteGenreCommand(id));
            if (!isRemoved)
                return ApiResponse.NotFound("Genre not found or could not be deleted");

            return ApiResponse.Success(isRemoved, "Genre has been deleted successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to delete genre", 500);
        }
    }

    #endregion
}
