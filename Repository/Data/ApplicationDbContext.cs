using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using Container = Core.Models.Container;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<StoreCustomerLocation>  storeCustomerLocations { get; set; }
        public DbSet<ApplicationOrMuamalah> ApplicationOrMuamalahs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
