using inventory_service.DTO;
using inventory_service.Entities;

namespace inventory_service.Services;
public class CategoryService
{
  public string GetCategories(int page, int limit)
  {
    Console.WriteLine($"Page: {page}, Limit: {limit}");
    return "GetCategories";
  }

  public int GetCategoryById(int id)
  {
    return id;
  }

  public Category CreateCategory(CreateCategoryDto category)
  {
    var newCategory = new Category
    {
      Id = 1,
      Name = category.Name,
      Description = category.Description
    };
    return newCategory;
  }

  public string UpdateCategory(int id, UpdateCategoryDto category)
  {
    Console.WriteLine($"UpdateCategory {category.Name}");
    return $"UpdateCategory {id}";
  }

  public string DeleteCategory(int id)
  {
    return $"DeleteCategory {id}";
  }
}