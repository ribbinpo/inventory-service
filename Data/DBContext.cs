using Microsoft.EntityFrameworkCore;

namespace inventory_service.Data.Entities;
public partial class InventoryDbContext(DbContextOptions<InventoryDbContext> options, IConfiguration configuration) : DbContext(options)
{
  private readonly IConfiguration _configuration = configuration;
  public virtual DbSet<Category> Categories { get; set; }
  public virtual DbSet<Manufacturer> Manufacturers { get; set; }
  public virtual DbSet<Product> Products { get; set; }
  public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      string? connectionString = _configuration.GetConnectionString("DefaultConnection");
      optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Unique constraints
    modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
    modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
    modelBuilder.Entity<Manufacturer>().HasIndex(m => m.Name).IsUnique();
    // Relationships
    modelBuilder.Entity<Product>()
      .HasOne(o => o.Manufacturer)
      .WithMany(m => m.Products)
      .HasForeignKey(o => o.ManufacturerId)
      .OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<Product>()
      .HasMany(m => m.Categories)
      .WithMany(m => m.Products)
      .UsingEntity<CategoryProduct>(
        l => l.HasOne(o => o.Category).WithMany(m => m.CategoryProducts),
        r => r.HasOne(o => o.Product).WithMany(m => m.CategoryProducts)
      );
    base.OnModelCreating(modelBuilder);
  }
}