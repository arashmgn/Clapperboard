using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator { get; } = mediator;

    protected static (int Page, int PageSize) Normalize(int page, int pageSize)
        => (Math.Max(page, 1), Math.Clamp(pageSize, 1, 100));
}
