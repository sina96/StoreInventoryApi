namespace StoreInventoryApi.Models;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public Address Address { get; set; } = new();

    public ICollection<Product> Products { get; set; } = new List<Product>();
}