using api.Models;
using IMDB.Application.Common;
using IMDB.Application.Dtos;
using IMDB.Application.Features.People.Commands.CreatePerson;
using IMDB.Application.Features.People.Commands.DeletePerson;
using IMDB.Application.Features.People.Commands.UpdatePerson;
using IMDB.Application.Features.People.Queries.GetPeople;
using IMDB.Application.Features.People.Queries.GetPeoplePaginated;
using IMDB.Application.Features.People.Queries.GetPersonById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class PersonController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await Mediator.Send(new GetPeopleQuery(), ct));

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetPeoplePaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<PersonDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var person = await Mediator.Send(new GetPersonByIdQuery(id), ct);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] PersonRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreatePersonCommand(dto.ImdbId, dto.FullName, dto.BirthDate, dto.Bio, dto.PhotoUrl), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdatePersonCommand(id, dto.ImdbId, dto.FullName, dto.BirthDate, dto.Bio, dto.PhotoUrl), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeletePersonCommand(id), ct);
        return NoContent();
    }
}
