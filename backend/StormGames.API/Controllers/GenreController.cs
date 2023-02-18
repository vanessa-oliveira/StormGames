using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Genres;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGenreQueries _genreQueries;

    public GenreController(IMediator mediator, IGenreQueries genreQueries)
    {
        _mediator = mediator;
        _genreQueries = genreQueries;
    }

    #region Commands
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpPost("CreateGenre")]
    public async Task<IActionResult> CreateGenre(CreateGenreCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpPut("UpdateGenre")]
    public async Task<IActionResult> UpdateGenre(UpdateGenreCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpDelete("DeleteGenre/{id:Guid}")]
    public async Task<IActionResult> DeleteGenre(Guid id)
    {
        var cmd = new DeleteGenreCommand
        {
            Id = id
        };
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    #endregion
    
    #region Queries
    
    [AllowAnonymous]
    [HttpGet("GetById/{id:Guid}")]
    public async Task<IActionResult> GetGenreById(Guid id)
    {
        var genre = await _genreQueries.GetGenreById(id);
        return Ok(genre);
    }

    [AllowAnonymous]
    [HttpGet("ListAllGenres")]
    public async Task<IActionResult> ListAllGenres()
    {
        var genres = await _genreQueries.GetAllGenres();
        return Ok(genres);
    }
    
    #endregion
}