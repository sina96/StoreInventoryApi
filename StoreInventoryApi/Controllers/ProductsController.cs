using Microsoft.AspNetCore.Mvc;
using StoreInventoryApi.DTOs;
using StoreInventoryApi.Models;
using StoreInventoryApi.Services;

namespace StoreInventoryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Product>> Get() => await service.GetAll();

    [HttpGet("active")]
    public async Task<IEnumerable<Product>> GetActive() => await service.GetActive();

    [HttpGet("with-reviews")]
    public async Task<IEnumerable<Product>> GetWithReviews() => await service.GetWithReviews();
    
    [HttpGet("projected")]
    public async Task<IEnumerable<ProductDto>> GetProjected()
    {
        return await service.GetProjected();
    }


    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Product>>> Filter(decimal min, decimal max)
    {
        var result = await service.FilterByPrice(min, max);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        var created = await service.Create(product);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var deleted = await service.SoftDelete(id);
        return deleted ? NoContent() : NotFound();
    }
}