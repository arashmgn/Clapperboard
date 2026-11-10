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
}
