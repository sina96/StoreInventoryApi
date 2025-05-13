using Microsoft.EntityFrameworkCore;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.ArticleName)
            .IsUnique();
        
        modelBuilder.Entity<Supplier>()
            .OwnsOne(s => s.Address);
       /* modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ArticleName = "Laptop", UnitPrice = 1000, Stock = 10, IsActive = true },
            new Product { Id = 2, ArticleName = "Mouse", UnitPrice = 50, Stock = 200, IsActive = true },
            new Product { Id = 3, ArticleName = "IPod", UnitPrice = 500, Stock = 0, IsActive = false }
        );*/
    }

    public DbSet<Product> Products => Set<Product>();
    //public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductReview> Reviews => Set<ProductReview>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
}