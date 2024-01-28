using Microsoft.AspNetCore.Mvc;

using inventory_service.DTO;
using inventory_service.Services;
using inventory_service.Entities;

namespace inventory_service.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ManufacturerController(ManufacturerService manufacturerService) : ControllerBase
{
  private readonly ManufacturerService _manufacturerService = manufacturerService;

  [HttpGet]
  [ApiExplorerSettings(GroupName = "Manufacturers")]
  public async Task<ActionResult<List<Manufacturer>>> GetManufacturers([FromQuery] int page, [FromQuery] int limit)
  {
    var _manufacturers = await _manufacturerService.FindAll(page, limit);
    return _manufacturers;
  }

  [HttpGet("{id}")]
  [ApiExplorerSettings(GroupName = "Manufacturers")]
  public async Task<ActionResult<Manufacturer>> GetManufacturerById(int id)
  {
    var _manufacturer = await _manufacturerService.FindById(id);
    if (_manufacturer == null)
    {
      return NotFound($"Manufacturer with id {id} not found");
    }
    return _manufacturer;
  }

  [HttpPost]
  public async Task<IActionResult> CreateManufacturer([FromBody] CreateManufacturerDTO manufacturer)
  {
    if (await _manufacturerService.IsManufacturerExists(manufacturer.Name))
    {
      return BadRequest("This Manufacturer already exists");
    }
    var _manufacturer = await _manufacturerService.CreateOne(manufacturer);
    return Created("CreateManufacturer", _manufacturer);
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateManufacturer(int id, [FromBody] UpdateManufacturerDTO manufacturer)
  {
    var _id = await _manufacturerService.UpdateOne(id, manufacturer);
    return Ok($"UpdateManufacturer {_id}");
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteManufacturer(int id)
  {
    var _id = await _manufacturerService.DeleteOne(id);
    return Ok($"DeleteManufacturer {_id}");
  }
}
