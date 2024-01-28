// For Many-to-Many relationship between Category and Product
namespace inventory_service.Entities;
public class CategoryProduct {
  public int CategoryId { get; set; }
  public required Category Category { get; set; }
  public int ProductId { get; set; }
  public required Product Product { get; set; }
}