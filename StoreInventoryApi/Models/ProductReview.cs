namespace StoreInventoryApi.Models;

public class ProductReview
{
    public int Id { get; set; }
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
