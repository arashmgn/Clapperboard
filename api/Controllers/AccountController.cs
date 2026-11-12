using IMDB.Domain.Entities;
using IMDB.Infrastructure.Identity;
using IMDB.Application.Common.Abstractions;
using IMDB.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
    }
}
