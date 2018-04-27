using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Api.Models;

namespace ProductStore.Api.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
