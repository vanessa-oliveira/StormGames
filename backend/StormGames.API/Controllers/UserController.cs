using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserQueries _userQueries;

    public UserController(IUserQueries userQueries)
    {
        _userQueries = userQueries;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpGet("ListActiveUsers")]
    public async Task<IActionResult> ListActiveUsers()
    {
        var activeUsers = await _userQueries.ListAllActiveUsers();
        return Ok(activeUsers);
    }
}