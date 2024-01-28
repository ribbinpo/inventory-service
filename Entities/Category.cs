namespace inventory_service.Entities;
public class Category
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  // Relationship
  public ICollection<CategoryProduct>? CategoryProducts { get; set; }
}