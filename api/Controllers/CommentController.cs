using api.Models;
using IMDB.Application.Dtos;
using IMDB.Application.Features.Comments.Commands.CreateComment;
using IMDB.Application.Features.Comments.Commands.DeleteComment;
using IMDB.Application.Features.Comments.Commands.UpdateComment;
using IMDB.Application.Features.Comments.Queries.GetCommentById;
using IMDB.Application.Features.Comments.Queries.GetCommentsPaginated;
using IMDB.Application.Features.Comments.Queries.GetMediaComments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class CommentController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        (page, pageSize) = Normalize(page, pageSize);
        var (items, totalCount) = await Mediator.Send(new GetCommentsPaginatedQuery(page, pageSize), ct);
        return Ok(new PagedResponse<CommentDto>(items, totalCount, page, pageSize));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var comment = await Mediator.Send(new GetCommentByIdQuery(id), ct);
        return comment is null ? NotFound() : Ok(comment);
    }

    [HttpGet("media/{mediaId:guid}")]
    public async Task<IActionResult> GetByMedia(Guid mediaId, CancellationToken ct)
        => Ok(await Mediator.Send(new GetMediaCommentsQuery(mediaId), ct));

    [HttpPost("media/{mediaId:guid}")]
    [Authorize]
    public async Task<IActionResult> Create(Guid mediaId, [FromBody] CommentRequestDto dto, CancellationToken ct)
    {
        var id = await Mediator.Send(new CreateCommentCommand(mediaId, dto.Text), ct);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] CommentRequestDto dto, CancellationToken ct)
    {
        await Mediator.Send(new UpdateCommentCommand(id, dto.Text), ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteCommentCommand(id), ct);
        return NoContent();
    }
}
