using MediatR;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Games;

namespace StormGames.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

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
}