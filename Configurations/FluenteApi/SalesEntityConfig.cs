using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleDevInHouse.Model;

namespace SaleDevInHouse.Configurations.FluenteApi
{
    public class SalesEntityConfig : IEntityTypeConfiguration<Sale>
    {
         public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .HasMaxLength(15)
                   .HasColumnType("int")
                   .IsRequired();

                    
            builder.Property(s => s.BuyerId)
                    .HasColumnName("BuyId")
                    .HasColumnType("int")
                    .HasMaxLength(20)                    
                    .IsRequired();

            builder.Property(s => s.SallerId)
                   .HasColumnName("SallerId")
                   .HasColumnType("int")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(s => s.SaleDate)
                   .HasColumnName("SaleDate")
                   .HasColumnType("datetime")
                   .IsRequired();
        }
    }
}