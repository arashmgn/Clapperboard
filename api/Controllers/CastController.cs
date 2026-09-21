using api.Dtos;
using api.Interfaces.IRepositories;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CastController : ControllerBase
{
    private readonly ICastRepository _castRepository;
    private readonly IMediaRepository _mediaRepository;
    private readonly IPersonRepository _personRepository;

    public CastController(ICastRepository castRepository, IMediaRepository mediaRepository, IPersonRepository personRepository)
    {
        _castRepository = castRepository;
        _mediaRepository = mediaRepository;
        _personRepository = personRepository;
    }

    #region Get Casts

    [HttpGet]
    public async Task<IActionResult> GetAllCasts([FromQuery] int? page, [FromQuery] int? pageSize)
    {
        try
        {
            if (page.HasValue && pageSize.HasValue)
            {
                var (casts, totalCount) = await _castRepository.GetAllPaginatedAsync(page.Value, pageSize.Value);
                var castDtoList = casts.Select(c => c.ToDto());

                return ApiResponse.Success(new
                {
                    TotalCount = totalCount,
                    Page = page.Value,
                    PageSize = pageSize.Value,
                    Data = castDtoList
                }, "Paginated casts retrieved successfully");
            }
            else
            {
                var casts = await _castRepository.GetAllAsync();
                var castDtoList = casts.Select(c => c.ToDto());
                return ApiResponse.Success(castDtoList, "All casts retrieved successfully");
            }
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve casts", 500);
        }
    }

    [HttpGet("media/{mediaId}")]
    public async Task<IActionResult> GetMediaCast([FromRoute] int mediaId, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        try
        {
            if (page.HasValue && pageSize.HasValue)
            {
                var (casts, total) = await _castRepository.GetMediaCastPaginatedAsync(mediaId, page.Value, pageSize.Value);
                var castDtoList = casts.Select(c => c.ToDto());

                return ApiResponse.Success(new
                {
                    TotalCount = total,
                    Page = page.Value,
                    PageSize = pageSize.Value,
                    Data = castDtoList
                }, "Paginated media casts retrieved successfully");
            }
            else
            {
                var casts = await _castRepository.GetMediaCastAsync(mediaId);
                var castDtoList = casts.Select(c => c.ToDto());
                return ApiResponse.Success(castDtoList, "Media casts retrieved successfully");
            }
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve media casts", 500);
        }
    }

    #endregion

    #region CRUD

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddMediaCast([FromBody] CastRequestDto castDto)
    {
        try
        {
            var media = await _mediaRepository.GetByIdAsync(castDto.MediaId);
            if (media == null)
                return ApiResponse.NotFound("Media not found");

            var person = await _personRepository.GetByIdAsync(castDto.PersonId);
            if (person == null)
                return ApiResponse.NotFound("Person not found");

            var cast = castDto.ToModel();
            var createdCast = await _castRepository.AddAsync(cast);
            if (createdCast == null)
                return ApiResponse.Error("Could not create cast", 500);

            return ApiResponse.Success(createdCast.ToDto(), "Cast added successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to add cast", 500);
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCast([FromRoute] int id, [FromBody] CastRequestDto castDto)
    {
        try
        {
            var cast = castDto.ToModel();
            cast.Id = id;
            var updatedCast = await _castRepository.UpdateAsync(cast);
            if (updatedCast == null)
                return ApiResponse.NotFound("Cast not found");

            return ApiResponse.Success(updatedCast.ToDto(), "Cast updated successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to update cast", 500);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCast(int id)
    {
        try
        {
            var cast = new Cast { Id = id };
            var isRemoved = await _castRepository.DeleteAsync(cast);
            if (!isRemoved)
                return ApiResponse.NotFound("Cast not found");

            return ApiResponse.Success(isRemoved, "Cast deleted successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to delete cast", 500);
        }
    }

    #endregion
}
