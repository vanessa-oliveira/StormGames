using MediatR;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Genres;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

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
    
    [HttpPost("CreateGenre")]
    public async Task<IActionResult> CreateGenre(CreateGenreCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpPut("UpdateGenre")]
    public async Task<IActionResult> UpdateGenre(UpdateGenreCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("DeleteGenre")]
    public async Task<IActionResult> DeleteGenre(DeleteGenreCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    #endregion
    
    #region Queries
    
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var genre = await _genreQueries.GetGenreById(id);
        return Ok(genre);
    }

    [HttpGet("ListAllGenres")]
    public async Task<IActionResult> ListAllGenres()
    {
        var genres = await _genreQueries.GetAllGenres();
        return Ok(genres);
    }
    
    #endregion
}