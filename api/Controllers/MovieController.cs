using Microsoft.AspNetCore.Mvc;
using IMDB.Infrastructure.Persistence;
using IMDB.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IMDB.Application.Common.Abstractions;
using IMDB.Domain.Entities;
using IMDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using api.Mappers;
using api.Helpers;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
}
