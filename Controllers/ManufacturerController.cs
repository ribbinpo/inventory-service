using Microsoft.AspNetCore.Mvc;

using inventory_service.DTO;
using inventory_service.Services;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ManufacturerController(ManufacturerService manufacturerService) : ControllerBase
{
  private readonly ManufacturerService _manufacturerService = manufacturerService;

    [HttpGet]
  [ApiExplorerSettings(GroupName = "Manufacturers")]
  public IActionResult GetManufacturers([FromQuery] int page, [FromQuery] int limit)
  {
    _manufacturerService.GetManufacturers(page, limit);
    return Ok("GetManufacturers");
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Manufacturers")]
  public IActionResult GetManufacturerById(int id)
  {
    var _id = _manufacturerService.GetManufacturerById(id);
    return Ok($"GetManufacturer {_id}");
  }

  [HttpPost]
  public IActionResult CreateManufacturer(CreateManufacturerDTO manufacturer)
  {
    var _manufacturer = _manufacturerService.CreateManufacturer(manufacturer);
    return Created("CreateManufacturer", _manufacturer);
  }

  [HttpPatch("{id}")]
  public IActionResult UpdateManufacturer(int id, [FromBody] UpdateManufacturerDTO manufacturer)
  {
    _manufacturerService.UpdateManufacturer(id, manufacturer);
    return Ok($"UpdateManufacturer {id}");
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteManufacturer(int id)
  {
    _manufacturerService.DeleteManufacturer(id);
    return Ok($"DeleteManufacturer {id}");
  }
}
