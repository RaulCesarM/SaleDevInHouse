using Microsoft.EntityFrameworkCore;
using SaleDevInHouse.Configurations.FluenteApi;
using SaleDevInHouse.Model;

namespace SaleDevInHouse.Data.Contexts {
    public class SalesContext : DbContext {

        private readonly IConfiguration _configuration;

        public SalesContext(IConfiguration configuration) {
            _configuration = configuration;
        }
    
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleCar> SalesCars { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder  optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConexaoDB"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SalesEntityConfig());
            modelBuilder.ApplyConfiguration(new SalesCarEntityConfig());
            modelBuilder.ApplyConfiguration(new DeliveryEntityConfig());

           */
        }






    }
}
