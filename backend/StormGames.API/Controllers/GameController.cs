using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Games;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

[Authorize]
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
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpPost("InsertGame")]
    public async Task<IActionResult> InsertGame(CreateGameCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpPut("UpdateGame")]
    public async Task<IActionResult> UpdateGame(UpdateGameCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpDelete("DeleteGame/{id:Guid}")]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var cmd = new DeleteGameCommand
        {
            Id = id
        };
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    #endregion
    
    #region Queries

    [AllowAnonymous]
    [HttpGet("ListAllGames")]
    public async Task<IActionResult> ListAllGames()
    {
        var games = await _gameQueries.GetAllGames();
        return Ok(games);
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id:Guid}")]
    public async Task<IActionResult> GetGameById(Guid id)
    {
        var game = await _gameQueries.GetGameById(id);
        return Ok(game);
    }

    #endregion
    
}