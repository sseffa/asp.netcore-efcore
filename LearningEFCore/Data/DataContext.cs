using LearningEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningEFCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
          : base(opts) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }

        public DbSet<ContactLocation> ContactLocations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ProductShipmentJunction> ProductShipmentJunctions { get; set; }
    }
}
