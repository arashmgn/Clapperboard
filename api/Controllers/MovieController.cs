using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using api.Interfaces;
using api.Interfaces.IRepositories;
using api.Repository;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Mappers;
using api.Helpers;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
}
