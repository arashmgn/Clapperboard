using Microsoft.AspNetCore.Mvc;
using api.Interfaces.IRepositories;
using api.Dtos;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Helpers;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    #region Get People

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int? page, [FromQuery] int? pageSize)
    {
        try
        {
            if (page.HasValue && pageSize.HasValue)
            {
                var (people, totalCount) = await _personRepository.GetAllPaginatedAsync(page.Value, pageSize.Value);
                var personDtoList = people.Select(p => p.ToPersonDisplayDto()).ToList();

                return ApiResponse.Success(new
                {
                    TotalCount = totalCount,
                    Page = page.Value,
                    PageSize = pageSize.Value,
                    Data = personDtoList
                }, "Paginated people retrieved successfully");
            }
            else
            {
                var people = await _personRepository.GetAllAsync();
                var personDtoList = people.Select(p => p.ToPersonDisplayDto()).ToList();
                return ApiResponse.Success(personDtoList, "People retrieved successfully");
            }
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve people", 500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] int id)
    {
        try
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ApiResponse.NotFound("Person not found");

            return ApiResponse.Success(person.ToPersonDetailDto(), "Person retrieved successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to retrieve person", 500);
        }
    }

    #endregion

    #region CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonRequestDto personDto)
    {
        try
        {
            var person = await _personRepository.AddAsync(personDto.ToPersonModel());
            if (person == null)
                return ApiResponse.Error("Failed to create person", 500);

            return ApiResponse.Success(person.ToPersonDisplayDto(), "Person created successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to create person", 500);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PersonRequestDto personDto)
    {
        try
        {
            var person = personDto.ToPersonModel();
            person.Id = id;

            var updatedPerson = await _personRepository.UpdateAsync(person);
            if (updatedPerson == null)
                return ApiResponse.NotFound("Person not found");

            return ApiResponse.Success(updatedPerson.ToPersonDetailDto(), "Person updated successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to update person", 500);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var person = new Person { Id = id };
            var isDeleted = await _personRepository.DeleteAsync(person);
            if (!isDeleted)
                return ApiResponse.NotFound("Person not found or could not be deleted");

            return ApiResponse.Success(isDeleted, "Person has been deleted successfully");
        }
        catch
        {
            return ApiResponse.Error("Failed to delete person", 500);
        }
    }

    #endregion
}
