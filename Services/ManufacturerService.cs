using inventory_service.DTO;
using inventory_service.Entities;

namespace inventory_service.Services;
public class ManufacturerService
{
  public string GetManufacturers(int page, int limit)
  {
    Console.WriteLine($"Page: {page}, Limit: {limit}");
    return "GetManufacturers";
  }

  public int GetManufacturerById(int id)
  {
    return id;
  }

  public Manufacturer CreateManufacturer(CreateManufacturerDTO manufacturer)
  {
    var newManufacturer = new Manufacturer
    {
      Id = 1,
      Name = manufacturer.Name,
      Email = manufacturer.Email,
      Phone = manufacturer.Phone,
      Address = manufacturer.Address
    };
    return newManufacturer;
  }

  public string UpdateManufacturer(int id, UpdateManufacturerDTO manufacturer)
  {
    Console.WriteLine($"UpdateManufacturer {manufacturer.Name}");
    return $"UpdateManufacturer {id}";
  }

  public string DeleteManufacturer(int id)
  {
    return $"DeleteManufacturer {id}";
  }
}
