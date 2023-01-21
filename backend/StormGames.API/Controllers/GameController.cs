using MediatR;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Games;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGameQueries _gameQueries;

    public GameController(IMediator mediator, IGameQueries gameQueries)
    {
        _mediator = mediator;
        _gameQueries = gameQueries;
    }

    #region Commands
    
    [HttpPost("InsertGame")]
    public async Task<IActionResult> InsertGame(CreateGameCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpPut("UpdateGame")]
    public async Task<IActionResult> UpdateGame(UpdateGameCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("DeleteGame")]
    public async Task<IActionResult> DeleteGame(DeleteGameCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    #endregion
    
    #region Queries

    [HttpGet("ListAllGames")]
    public async Task<IActionResult> ListAllGames()
    {
        var games = await _gameQueries.GetAllGames();
        return Ok(games);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _gameQueries.GetGameById(id);
        return Ok(game);
    }

    #endregion
    
}