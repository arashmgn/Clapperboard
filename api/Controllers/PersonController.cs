using Microsoft.AspNetCore.Mvc;
using IMDB.Application.Dtos;
using api.Mappers;
using IMDB.Domain.Entities;
using IMDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using api.Helpers;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
}
