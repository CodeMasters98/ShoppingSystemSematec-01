using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Domain.Entities;

namespace ShoppingSystemSematec.Infrastructure.Persistence.Configurations;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_BASE_Brand");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250);
    }
}
