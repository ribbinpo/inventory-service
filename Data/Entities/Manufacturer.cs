namespace inventory_service.Data.Entities;
public class Manufacturer
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Address { get; set; }
  // Relationship
  public ICollection<Product>? Products { get; set; }
}