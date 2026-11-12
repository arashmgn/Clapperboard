using System.Security.Claims;
using IMDB.Application.Dtos;
using API.Dtos;
using IMDB.Application.Common.Abstractions;
using api.Mappers;
using IMDB.Domain.Entities;
using IMDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

namespace api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
}
