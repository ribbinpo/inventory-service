using System.ComponentModel.DataAnnotations;

namespace inventory_service.DTO;

public class CreateManufacturerDTO
{
  [Required]
  [MaxLength(50)]
  public string? Name { get; set; }
  [Required]
  [EmailAddress]
  public string? Email { get; set; }
  [Required]
  [Phone]
  public string? Phone { get; set; }
  [Required]
  public string? Address { get; set; }
}

public class UpdateManufacturerDTO
{
  [MaxLength(50)]
  public string? Name { get; set; }
  [EmailAddress]
  public string? Email { get; set; }
  [Phone]
  public string? Phone { get; set; }
  public string? Address { get; set; }
}