using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Roles;
using StormGames.Application.Queries;

namespace StormGames.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRoleQueries _roleQueries;

    public RoleController(IMediator mediator, IRoleQueries roleQueries)
    {
        _mediator = mediator;
        _roleQueries = roleQueries;
    }

    #region Commands
    
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(UpdateRoleCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(DeleteRoleCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    #endregion

    #region Queries

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "ADMIN")]
    [HttpGet("ListAllRoles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleQueries.GetAllRoles();
        return Ok(roles);
    }

    [HttpGet("GetRoleById")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var role = await _roleQueries.GetRoleById(id);
        return Ok(role);
    }

    #endregion
    
}