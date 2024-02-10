using inventory_service.DTO;
using inventory_service.Data.Entities;
using inventory_service.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController(CategoryService categoryService) : ControllerBase
{
  private readonly CategoryService _categoryService = categoryService;

  [HttpGet]
  [ApiExplorerSettings(GroupName = "Categories")]
  public async Task<ActionResult<List<Category>>> GetCategories([FromQuery] int page, [FromQuery] int limit)
  {
    var _categories = await _categoryService.FindAll(page, limit);
    return _categories;
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Categories")]
  public async Task<ActionResult<Category>> GetCategoryById(int id)
  {
    var _category = await _categoryService.FindById(id);
    if (_category == null)
    {
      return NotFound($"Category with id {id} not found");
    }
    return _category;
  }

  [HttpPost]
  public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto category)
  {
    if (await _categoryService.IsCategoryExists(category.Name))
    {
      return BadRequest("This Category already exists");
    }
    var _category = await _categoryService.CreateOne(category);
    return Created("CreateCategory", _category);
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto category)
  {
    if (category.Name != null && await _categoryService.IsCategoryExists(category.Name))
    {
      return BadRequest("This Category already exists");
    }
    var _id = await _categoryService.UpdateOne(id, category);
    return Ok($"UpdateCategory {_id}");
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCategory(int id)
  {
    var _id = await _categoryService.DeleteOne(id);
    return Ok($"DeleteCategory {_id}");
  }
}
