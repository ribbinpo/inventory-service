using Microsoft.EntityFrameworkCore;

using inventory_service.DTO;
using inventory_service.Data.Entities;

namespace inventory_service.Data.Services;
public class ManufacturerService(InventoryDbContext dbContext)
{
  private readonly InventoryDbContext _dbContext = dbContext;

  public async Task<List<Manufacturer>> FindAll(int page, int limit)
  {
    try
    {
      var manufacturers = await _dbContext.Manufacturers.Skip((page - 1) * limit).Take(limit).ToListAsync();
      return manufacturers;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<Manufacturer?> FindById(int id)
  {
    try
    {
      var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(c => c.Id == id);
      return manufacturer;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<Manufacturer> CreateOne(CreateManufacturerDTO manufacturer)
  {
    var newManufacturer = new Manufacturer
    {
      Name = manufacturer.Name,
      Email = manufacturer.Email,
      Phone = manufacturer.Phone,
      Address = manufacturer.Address
    };
    try
    {
      await _dbContext.Manufacturers.AddAsync(newManufacturer);
      var id = await _dbContext.SaveChangesAsync();
      newManufacturer.Id = id;
      return newManufacturer;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<bool> IsManufacturerExists(string name)
  {
    return await _dbContext.Manufacturers.AnyAsync(c => c.Name == name);
  }

  public async Task<int> UpdateOne(int id, UpdateManufacturerDTO manufacturer)
  {
    try
    {
      var _manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
      _manufacturer.Name = manufacturer.Name ?? _manufacturer.Name;
      _manufacturer.Email = manufacturer.Email ?? _manufacturer.Email;
      _manufacturer.Phone = manufacturer.Phone ?? _manufacturer.Phone;
      _manufacturer.Address = manufacturer.Address ?? _manufacturer.Address;
      var _id = await _dbContext.SaveChangesAsync();
      return _manufacturer.Id;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      throw new Exception(e.Message);
    }
  }

  public async Task<int> DeleteOne(int id)
  {
    var _manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception($"Category with id {id} not found");
    _dbContext.Manufacturers.Remove(_manufacturer);
    var _id = await _dbContext.SaveChangesAsync();
    return _manufacturer.Id;
  }
}
