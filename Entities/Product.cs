using System.ComponentModel;

namespace inventory_service.Entities;
public class Product
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public float Price { get; set; }
  public int Quantity { get; set; }
  [DefaultValue(0)]
  public int? ReorderThreshold { get; set; }
  public int ManufacturerId { get; set; }
  // public Manufacturer Manufacturer { get; set; }
}