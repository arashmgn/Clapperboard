using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using API.Dtos;
using api.Interfaces.IRepositories;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using api.Mappers;
using api.Models;
using api.Helpers;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreRepository _genreRepository;

    public GenreController(ApplicationDbContext context)
    {
        _genreRepository = new GenreRepository(context);
    }

    #region Get Genres

    // // همه ژانرها
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int? page, [FromQuery] int? pageSize)
    {
        try
        {
            if (page.HasValue && pageSize.HasValue)
            {
                // پیجینیشن فعال
                var (genres, totalCount) = await _genreRepository.GetAllPaginatedAsync(page.Value, pageSize.Value);
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
                // همه داده‌ها
                var genres = await _genreRepository.GetAllAsync();
                var genreDto = genres.Select(g => g.ToGenreDto()).ToList();
                return ApiResponse.Success(genreDto, "Genres retrieved successfully");
            }
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve genres", 500);
        }
    }

    // [HttpGet]
    // public async Task<IActionResult> GetList()
    // {
    //     try
    //     {
    //         var genres = await _genreRepository.GetAllAsync();
    //         var genreDto = genres.Select(g => g.ToGenreDto()).ToList();
    //         return ApiResponse.Success(genreDto, "Genres retrieved successfully");
    //     }
    //     catch
    //     {
    //         return ApiResponse.Error("Failed to retrieve genres", 500);
    //     }
    // }

    // // ژانرها با پیجینیشن
    // [HttpGet("paginated")]
    // public async Task<IActionResult> GetListPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    // {
    //     try
    //     {
    //         var (genres, totalCount) = await _genreRepository.GetAllPaginatedAsync(page, pageSize);
    //         var genreDto = genres.Select(g => g.ToGenreDto()).ToList();
    //
    //         return ApiResponse.Success(new
    //         {
    //             TotalCount = totalCount,
    //             Page = page,
    //             PageSize = pageSize,
    //             Data = genreDto
    //         }, "Paginated genres retrieved successfully");
    //     }
    //     catch
    //     {
    //         return ApiResponse.Error("Failed to retrieve paginated genres", 500);
    //     }
    // }

    // جزئیات یک ژانر
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {
        try
        {
            var genre = await _genreRepository.GetByIdAsync(id);
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
            var genre = genreDto.ToGenreModel();
            genre = await _genreRepository.AddAsync(genre);
            if (genre == null)
                return ApiResponse.Error("Failed to create genre", 500);

            return ApiResponse.Success(genre.ToGenreDto(), "Genre created successfully");
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
            var genre = new Genre
            {
                Id = id,
                Title = genreDto.Title
            };

            genre = await _genreRepository.UpdateAsync(genre);
            if (genre == null)
                return ApiResponse.NotFound("Genre not found");

            return ApiResponse.Success(genre.ToGenreDto(), "Genre updated successfully");
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
            var genre = new Genre { Id = id };
            var isRemoved = await _genreRepository.DeleteAsync(genre);
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
