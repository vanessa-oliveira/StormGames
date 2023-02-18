using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Users;
using StormGames.Application.Queries;
using StormGames.Application.Queries.Models;
using StormGames.Domain.Entities;

namespace StormGames.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserQueries _userQueries;

    public AuthController(IMediator mediator, IUserQueries userQueries)
    {
        _mediator = mediator;
        _userQueries = userQueries;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserCommand cmd)
    {
        var user = await _mediator.Send(cmd);
        return Ok(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
}