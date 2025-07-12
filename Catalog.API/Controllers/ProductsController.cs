using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var result = await productService.GetProducts();
        if (result is null)
            return NotFound("Products not found");
        return Ok(result);
    }


    [HttpGet("Get/{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> GetById(int? id)
    {
        if (id is null)
            return BadRequest("Id cannot be null");
        var result = await productService.GetById(id);
        if (result is null)
            return NotFound($"Product with Id {id} not found");
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO product)
    {
        if (product is null)
            return BadRequest("Invalid Data");

        await productService.Add(product);

        return new CreatedAtRouteResult("GetProduct", new { Id = product.Id }, product);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO product)
    {
        if (product is null)
            return BadRequest("Invalid Data");

        var existingProduct = await productService.GetById(product.Id);

        if (existingProduct is null)
            return NotFound("Product not found");

        await productService.Update(product);

        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(int? id)
    {
        if (id is null)
            return BadRequest("Id cannot be null");

        var existingProduct = await productService.GetById(id);

        if (existingProduct is null)
            return NotFound("Product not found");

        await productService.Delete(id);

        return NoContent();
    }
}
