using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using API.Dtos;
using api.Mappers;
using api.Helpers;
using IMDB.Application.Genres.Commands.CreateGenre;
using IMDB.Application.Genres.Commands.DeleteGenre;
using IMDB.Application.Genres.Commands.UpdateGenre;
using IMDB.Application.Genres.Queries.GetGenreById;
using IMDB.Application.Genres.Queries.GetGenres;
using IMDB.Application.Genres.Queries.GetGenresPaginated;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
}
