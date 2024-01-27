using inventory_service.DTO;
using inventory_service.Entities;

namespace inventory_service.Services;
public class ProductService
{
  public string GetProducts(int page, int limit)
  {
    Console.WriteLine($"Page: {page}, Limit: {limit}");
    return "GetProducts";
  }

  public int GetProductById(int id)
  {
    return id;
  }

  public Product CreateProduct(CreateProductDTO product)
  {
    var newProduct = new Product
    {
      Id = 1,
      Name = product.Name,
      Description = product.Description,
      Price = product.Price,
      Quantity = product.Quantity,
      ReorderThreshold = product.ReorderThreshold,
      ManufacturerId = product.ManufacturerId
    };
    return newProduct;
  }

  public string UpdateProduct(int id, UpdateProductDTO product)
  {
    Console.WriteLine($"UpdateProduct {product.Name}");
    return $"UpdateProduct {id}";
  }

  public string DeleteProduct(int id)
  {
    return $"DeleteProduct {id}";
  }
}