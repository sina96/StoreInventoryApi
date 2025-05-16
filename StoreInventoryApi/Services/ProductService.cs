using StoreInventoryApi.DTOs;
using StoreInventoryApi.Models;
using StoreInventoryApi.Repositories;

namespace StoreInventoryApi.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task<IEnumerable<Product>> GetAll() =>
        await unitOfWork.Products.GetAllAsync();

    public async Task<Product?> GetById(int id) =>
        await unitOfWork.Products.GetByIdAsync(id);

    public async Task<Product> Create(Product product)
    {
        await unitOfWork.Products.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await unitOfWork.Products.GetByIdAsync(id);
        if (product is null) return false;

        await unitOfWork.Products.DeleteAsync(product);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> SoftDelete(int id)
    {
        var updated = await unitOfWork.Products.SoftDeleteAsync(id);
        if (!updated) return false;

        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetActive() =>
        await unitOfWork.Products.GetActiveAsync();

    public async Task<IEnumerable<Product>> GetWithReviews() =>
        await unitOfWork.Products.GetWithReviewsAsync();

    public async Task<IEnumerable<ProductDto>> GetProjected() =>
        await unitOfWork.Products.GetProjectedAsync();

    public async Task<IEnumerable<Product>> FilterByPrice(decimal min, decimal max) =>
        await unitOfWork.Products.FilterByPriceAsync(min, max);
}