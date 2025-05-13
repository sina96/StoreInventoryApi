namespace StoreInventoryApi.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public string? SupplierName { get; set; } // nullable in case there's no supplier
}