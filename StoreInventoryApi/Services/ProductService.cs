using Microsoft.EntityFrameworkCore;
using StoreInventoryApi.Data;
using StoreInventoryApi.DTOs;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Services;

public class ProductService(AppDbContext context) : IProductService
{
    public async Task<IEnumerable<Product>> GetAll() =>
        await context.Products.ToListAsync();

    public async Task<IEnumerable<Product>> GetActive() =>
        await context.Products.Where(p => p.IsActive).ToListAsync();

    public async Task<IEnumerable<Product>> GetWithReviews() =>
        await context.Products.Include(p => p.Reviews).ToListAsync();

    public async Task<IEnumerable<ProductDto>> GetProjected()
    {
        return await context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                SupplierName = p.Supplier != null ? p.Supplier.Name : null
            })
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> FilterByPrice(decimal min, decimal max) =>
        await context.Products
            .Where(p => p.UnitPrice >= min && p.UnitPrice <= max)
            .ToListAsync();

    public async Task<Product?> GetById(int id) =>
        await context.Products.FindAsync(id);

    public async Task<Product> Create(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> SoftDelete(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null) return false;

        product.IsActive = false;
        await context.SaveChangesAsync();
        return true;
    }
}