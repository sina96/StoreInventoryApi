using StoreInventoryApi.DTOs;

namespace StoreInventoryApi.Services;

using Models;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetActive();
    Task<IEnumerable<Product>> GetWithReviews();
    Task<IEnumerable<ProductDto>> GetProjected();
    Task<IEnumerable<Product>> FilterByPrice(decimal min, decimal max);
    Task<Product?> GetById(int id);
    Task<Product> Create(Product product);
    Task<bool> SoftDelete(int id);
}

