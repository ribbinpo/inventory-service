using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace inventory_service.DTO;

public class CreateProductDTO
{
  [Required]
  [MaxLength(50)]
  public string? Name { get; set; }
  [Required]
  public string? Description { get; set; }
  [Required]
  public float Price { get; set; }
  [Required]
  public int Quantity { get; set; }
  [DefaultValue(0)]
  public int? ReorderThreshold { get; set; }
  public int ManufacturerId { get; set; }
}

public partial class UpdateProductDTO
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public float? Price { get; set; }
  public int? Quantity { get; set; }
  public int? ReorderThreshold { get; set; }

  // public int? ManufacturerId { get; set; }
}