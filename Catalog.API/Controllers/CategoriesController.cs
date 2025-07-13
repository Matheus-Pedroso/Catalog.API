using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet("/GetAll")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var result = await categoryService.GetCategories();
        if (result is null)
            return NotFound("Categories not found");

        return Ok(result);
    }

    [HttpGet("Get/{id}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> GetById(int? id)
    {
        if (id is null)
            return BadRequest("Id cannot be null");

        var result = await categoryService.GetById(id);

        if (result is null)
            return NotFound($"Category with Id {id} not found");

        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<ActionResult> Add([FromBody] CategoryDTO category)
    {
        if (category is null)
            return BadRequest("Invalid Data");

        await categoryService.Add(category);

        return new CreatedAtRouteResult("GetCategory", new {id = category.Id}, category);
    }

    [HttpPut("Update")]
    public async Task<ActionResult> Update(CategoryDTO category)
    {
        if (category is null)
            return BadRequest("Invalid Data");

        var existingCategory = await categoryService.GetById(category.Id);

        if (existingCategory is null)
            return NotFound($"Category with Id {category.Id} not found");

        await categoryService.Update(category);

        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id is null)
            return BadRequest("Id cannot be null");

        var existingCategory = await categoryService.GetById(id);

        if (existingCategory is null)
            return NotFound($"Category with Id {id} not found");

        await categoryService.Delete(id);

        return NoContent();
    }

}
