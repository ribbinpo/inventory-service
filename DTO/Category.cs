using System.ComponentModel.DataAnnotations;

namespace inventory_service.DTO;
public class CreateCategoryDto
{
  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
}

public class UpdateCategoryDto
{
  public string? Name { get; set; }
  public string? Description { get; set; }
}