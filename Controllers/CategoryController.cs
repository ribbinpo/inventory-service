using inventory_service.DTO;
using inventory_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController(CategoryService categoryService) : ControllerBase
{
  private readonly CategoryService _categoryService = categoryService;

  [HttpGet]
  [ApiExplorerSettings(GroupName = "Categories")]
  public IActionResult GetCategories([FromQuery] int page, [FromQuery] int limit)
  {
    _categoryService.GetCategories(page, limit);
    return Ok("GetCategories");
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Categories")]
  public IActionResult GetCategoryById(int id)
  {
    var _id = _categoryService.GetCategoryById(id);
    return Ok($"GetCategory {_id}");
  }

  [HttpPost]
  public IActionResult CreateCategory([FromBody] CreateCategoryDto category)
  {
    var _category = _categoryService.CreateCategory(category);
    return Created("CreateCategory", _category);
  }

  [HttpPatch("{id}")]
  public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto category)
  {
    _categoryService.UpdateCategory(id, category);
    return Ok($"UpdateCategory {id}");
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteCategory(int id)
  {
    _categoryService.DeleteCategory(id);
    return Ok($"DeleteCategory {id}");
  }
}
