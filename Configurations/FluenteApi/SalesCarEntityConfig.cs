using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleDevInHouse.Model;

namespace SaleDevInHouse.Configurations.FluenteApi
{
    public class SalesCarEntityConfig : IEntityTypeConfiguration<SaleCar>
    {
        public void Configure(EntityTypeBuilder<SaleCar> builder)
        {
            builder.ToTable("SaleCar");
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id)
                   .HasMaxLength(15)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(sc => sc.SaleId)
                   .HasColumnType("int")
                   .HasMaxLength(15)
                   .HasColumnName("SaleId");
                   
            
            builder.Property(sc => sc.CarId)
                   .HasColumnName("CarId")
                   .HasColumnType("int")
                   .HasMaxLength(15);                  
                   

            builder.Property(sc => sc.UnitPrice)
                   .HasColumnName("UnitPrice")
                   .HasColumnType("decimal")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(sc => sc.Amount)
                  .HasColumnName("Amount")
                  .HasColumnType("int")
                  .HasMaxLength(15)
                  .IsRequired();
        }
    }
}