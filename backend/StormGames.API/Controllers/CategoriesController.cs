using MediatR;
using Microsoft.AspNetCore.Mvc;
using StormGames.Application.Commands.Categories;
using StormGames.Application.Queries;
using StormGames.Application.Queries.Models;

namespace StormGames.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICategoryQueries _categoryQueries;

    public CategoriesController(IMediator mediator, ICategoryQueries categoryQueries)
    {
        _mediator = mediator;
        _categoryQueries = categoryQueries;
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryQueries.GetCategoryById(id);
        return Ok(category);
    }

    [HttpGet("ListAllCategories")]
    public async Task<IActionResult> ListAllCategories()
    {
        var categories = await _categoryQueries.GetAllCategories();
        return Ok(categories);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
}