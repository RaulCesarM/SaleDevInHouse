using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleDevInHouse.Model;


namespace SaleDevInHouse.Configurations.FluenteApi
{
    public class DeliveryEntityConfig : IEntityTypeConfiguration<Delivery> 
    {
        public void Configure(EntityTypeBuilder<Delivery> builder )
        {
            builder.ToTable("Delivery");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                  .HasMaxLength(15)
                  .HasColumnType("int")
                  .IsRequired();

            builder.Property(d => d.AddressId)
                   .HasColumnName("AddressId")
                   .HasColumnType("int")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(d => d.SaleId)
                   .HasColumnName("SaleId")
                   .HasColumnType("int")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(d => d.DeliveryForecast)
                   .HasColumnName("DeliveryForecast")
                   .HasColumnType("datetime")
                   .HasMaxLength(10)
                   .IsRequired();


        }

      
    }
}