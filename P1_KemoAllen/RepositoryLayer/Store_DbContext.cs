using System;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace RepositoryLayer
{
    public class Store_DbContext: DbContext
    {
        //public DbSet<> of objects
        public Store_DbContext()
        { }
        public Store_DbContext(DbContextOptions<Store_DbContext> options) : base(options)
        { }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:kemoazserver.database.windows.net,1433;Initial Catalog=p0_mysql;Persist Security Info=False;"
                + "User ID=kemoallen;Password=Sholos_03;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
