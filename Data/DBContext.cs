using Microsoft.EntityFrameworkCore;

namespace inventory_service.Data.Entities;
public partial class InventoryDbContext(DbContextOptions<InventoryDbContext> options, IConfiguration configuration) : DbContext(options)
{
  private readonly IConfiguration _configuration = configuration;
  public virtual DbSet<Category> Categories { get; set; }
  public virtual DbSet<Manufacturer> Manufacturers { get; set; }
  public virtual DbSet<Product> Products { get; set; }

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
    modelBuilder.Entity<Product>().HasOne(p => p.Manufacturer).WithMany(m => m.Products).HasForeignKey(p => p.ManufacturerId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
    modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
    modelBuilder.Entity<Manufacturer>().HasIndex(m => m.Name).IsUnique();
    modelBuilder.Entity<CategoryProduct>().HasKey(cp => new { cp.CategoryId, cp.ProductId });
    modelBuilder.Entity<CategoryProduct>().HasOne(cp => cp.Category).WithMany(c => c.CategoryProducts).HasForeignKey(cp => cp.CategoryId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<CategoryProduct>().HasOne(cp => cp.Product).WithMany(p => p.CategoryProducts).HasForeignKey(cp => cp.ProductId).OnDelete(DeleteBehavior.Restrict);
    base.OnModelCreating(modelBuilder);
  }
}