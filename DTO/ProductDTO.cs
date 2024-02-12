using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace inventory_service.DTO;

public class CreateProductDTO
{
  [Required]
  [MaxLength(50)]
  public required string Name { get; set; }
  public string? Description { get; set; }
  [Required]
  public required float Price { get; set; }
  [Required]
  public required int Quantity { get; set; }
  [DefaultValue(0)]
  public int? ReorderThreshold { get; set; }
  public required int ManufacturerId { get; set; }
  public List<int> CategoryIds { get; set; } = [];
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