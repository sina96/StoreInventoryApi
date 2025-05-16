using System.Threading.Tasks;

namespace StoreInventoryApi.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    // Add other repositories as needed, e.g.:
    // ISupplierRepository Suppliers { get; }

    Task<int> CompleteAsync(); // Save all changes
}