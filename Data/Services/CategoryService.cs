using Microsoft.EntityFrameworkCore;

using inventory_service.DTO;
using inventory_service.Data.Entities;

namespace inventory_service.Data.Services;
public class CategoryService(InventoryDbContext dbContext)
{
  private readonly InventoryDbContext _dbContext = dbContext;

  public async Task<List<Category>> FindAll(int page, int limit)
  {
    try
    {
      var categories = await _dbContext.Categories.Skip((page - 1) * limit).Take(limit).ToListAsync();
      return categories;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<Category?> FindById(int id)
  {
    try
    {
      var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
      return category;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<Category> CreateOne(CreateCategoryDto category)
  {
    var newCategory = new Category()
    {
      Name = category.Name,
      Description = category.Description
    };
    try
    {
      await _dbContext.Categories.AddAsync(newCategory);
      var id = await _dbContext.SaveChangesAsync();
      newCategory.Id = id;
      return newCategory;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<bool> IsCategoryExists(string name)
  {
    return await _dbContext.Categories.AnyAsync(c => c.Name == name);
  }

  public async Task<int> UpdateOne(int id, UpdateCategoryDto category)
  {
    try
    {
      var _category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
      _category.Name = category.Name ?? _category.Name;
      _category.Description = category.Description ?? _category.Description;
      var _id = await _dbContext.SaveChangesAsync();
      return _category.Id;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<int> DeleteOne(int id)
  {
    var _category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
    _dbContext.Categories.Remove(_category);
    var _id = await _dbContext.SaveChangesAsync();
    return _category.Id;
  }
}