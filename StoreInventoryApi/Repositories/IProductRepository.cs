using StoreInventoryApi.DTOs;
using StoreInventoryApi.Models;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetActiveAsync();
    Task<IEnumerable<Product>> GetWithReviewsAsync();
    Task<IEnumerable<Product>> FilterByPriceAsync(decimal min, decimal max);
    Task<IEnumerable<ProductDto>> GetProjectedAsync();
    Task AddAsync(Product product);
    Task DeleteAsync(Product product);
    Task<bool> SoftDeleteAsync(int id);
}