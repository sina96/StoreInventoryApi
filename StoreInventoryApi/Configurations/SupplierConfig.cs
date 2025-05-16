using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Configurations;

public class SupplierConfig : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.Street).IsRequired();
            address.Property(a => a.City).IsRequired();
            address.Property(a => a.ZipCode).IsRequired();
        });

        builder.HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);
    }
}