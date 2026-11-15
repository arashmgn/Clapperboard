using IMDB.Application.Dtos;
using IMDB.Application.Features.Account.Commands.Login;
using IMDB.Application.Features.Account.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AccountController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
        => Ok(await Mediator.Send(new RegisterCommand(dto.UserName, dto.Email, dto.Password), ct));

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
        => Ok(await Mediator.Send(new LoginCommand(dto.UserName, dto.Password), ct));
}
