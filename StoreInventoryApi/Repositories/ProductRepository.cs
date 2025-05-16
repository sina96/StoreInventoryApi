using Microsoft.EntityFrameworkCore;
using StoreInventoryApi.Data;
using StoreInventoryApi.DTOs;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await context.Products.FindAsync(id);

    public async Task<IEnumerable<Product>> GetActiveAsync() =>
        await context.Products.Where(p => p.IsActive).ToListAsync();

    public async Task<IEnumerable<Product>> GetWithReviewsAsync() =>
        await context.Products.Include(p => p.Reviews).ToListAsync();

    public async Task<IEnumerable<Product>> FilterByPriceAsync(decimal min, decimal max) =>
        await context.Products
            .Where(p => p.UnitPrice >= min && p.UnitPrice <= max)
            .ToListAsync();

    public async Task<IEnumerable<ProductDto>> GetProjectedAsync() =>
        await context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                SupplierName = p.Supplier != null ? p.Supplier.Name : null
            })
            .ToListAsync();

    public Task AddAsync(Product product)
    {
        context.Products.Add(product);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null) return false;

        product.IsActive = false;
        return true;
    }
}