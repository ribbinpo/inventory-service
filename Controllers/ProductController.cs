using Microsoft.AspNetCore.Mvc;

using inventory_service.DTO;
using inventory_service.Services;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
  private readonly ProductService _productService = productService;

    [HttpGet]
  [ApiExplorerSettings(GroupName = "Products")]
  public IActionResult GetProducts([FromQuery] int page, [FromQuery] int limit)
  {
    _productService.GetProducts(page, limit);
    return Ok("GetProducts");
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Products")]
  public IActionResult GetProductById(int id)
  {
    var _id = _productService.GetProductById(id);
    return Ok($"GetProduct {_id}");
  }

  [HttpPost]
  public IActionResult CreateProduct(CreateProductDTO product)
  {
    var _product = _productService.CreateProduct(product);
    return Created("CreateProduct", _product);
  }

  [HttpPatch("{id}")]
  public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDTO product)
  {
    _productService.UpdateProduct(id, product);
    return Ok($"UpdateProduct {id}");
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteProduct(int id)
  {
    _productService.DeleteProduct(id);
    return Ok($"DeleteProduct {id}");
  }
}
