using Microsoft.EntityFrameworkCore;

using inventory_service.DTO;
using inventory_service.Data.Entities;

namespace inventory_service.Data.Services;
public class ProductService(InventoryDbContext dbContext)
{
  private readonly InventoryDbContext _dbContext = dbContext;
  public async Task<List<Product>> FindAll(int page, int limit)
  {
    try
    {
      var product = await _dbContext.Products.Skip((page - 1) * limit).Take(limit).ToListAsync();
      return product;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<Product?> FindById(int id)
  {
    try
    {
      var product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
      return product;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  // TODO: Relationship of manufacturer and category also
  public async Task<Product> CreateOne(CreateProductDTO product)
  {
    var newProduct = new Product
    {
      Name = product.Name,
      Description = product.Description,
      Price = product.Price,
      Quantity = product.Quantity,
      ReorderThreshold = product.ReorderThreshold,
      ManufacturerId = product.ManufacturerId
    };
    try
    {
      await _dbContext.Products.AddAsync(newProduct);
      var id = await _dbContext.SaveChangesAsync();
      newProduct.Id = id;
      return newProduct;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<bool> IsProductExists(string name)
  {
    return await _dbContext.Products.AnyAsync(c => c.Name == name);
  }

  // TODO: Relationship of manufacturer and category also
  public async Task<int> UpdateOne(int id, UpdateProductDTO product)
  {
    try
    {
      var _product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
      _product.Name = product.Name ?? _product.Name;
      _product.Description = product.Description ?? _product.Description;
      _product.Price = product.Price ?? _product.Price;
      _product.Quantity = product.Quantity ?? _product.Quantity;
      _product.ReorderThreshold = product.ReorderThreshold ?? _product.ReorderThreshold;
      // TODO: Update Relationship of manufacturer
      var _id = await _dbContext.SaveChangesAsync();
      return _product.Id;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  // TODO: Relationship of manufacturer and category also
  public async Task<int> DeleteOne(int id)
  {
    var _products = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
    _dbContext.Products.Remove(_products);
    var _id = await _dbContext.SaveChangesAsync();
    return _products.Id;
  }

  // TODO:
  // public async Task<bool> AddProductCategory(int productId, int categoryId)
  // {
  // } 
}