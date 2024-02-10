using Microsoft.AspNetCore.Mvc;

using inventory_service.DTO;
using inventory_service.Data.Services;
using inventory_service.Data.Entities;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
  private readonly ProductService _productService = productService;

  [HttpGet]
  [ApiExplorerSettings(GroupName = "Products")]
  public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] int page, [FromQuery] int limit)
  {
    var _products = await _productService.FindAll(page, limit);
    return _products;
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Products")]
  public async Task<ActionResult<Product>> GetProductById(int id)
  {
    var _product = await _productService.FindById(id);
    if (_product == null)
    {
      return NotFound($"Product with id {id} not found");
    }
    return _product;
  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO product)
  {
    if (await _productService.IsProductExists(product.Name))
    {
      return BadRequest("This Product already exists");
    }
    var _product = await _productService.CreateOne(product);
    return Created("CreateProduct", _product);
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO product)
  {
    if (product.Name != null && await _productService.IsProductExists(product.Name))
    {
      return BadRequest("This Category already exists");
    }
    var _id = await _productService.UpdateOne(id, product);
    return Ok($"UpdateProduct {_id}");
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    var _id = await _productService.DeleteOne(id);
    return Ok($"DeleteProduct {_id}");
  }
}
