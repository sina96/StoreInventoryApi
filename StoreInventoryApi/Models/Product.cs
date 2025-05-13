namespace StoreInventoryApi.Models;

public class Product
{
    public int Id { get; set; } // Primary Key
    public string ArticleName { get; set; } = null!;
    public string ProductName { get; set; } = string.Empty;
    //public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
    //public Category? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
    
    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
}
