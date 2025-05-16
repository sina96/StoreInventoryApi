using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductName)
            .IsRequired();

        builder.HasIndex(p => p.ProductName)
            .IsUnique();

        builder.HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId);

        builder.Property(p => p.UnitPrice)
            .HasPrecision(18, 2);

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);
    }
}