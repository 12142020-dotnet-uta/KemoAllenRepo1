using Microsoft.EntityFrameworkCore;
using System;

namespace P0_KemoAllen
{
    public class Store_DbContext : DbContext
    {
        //public DbSet<> of objects
        public DbSet<Customer> customers {get; set;}
        public DbSet<Location> locations {get; set;}
        public DbSet<Order> orders {get; set;}
        public DbSet<Inventory> inventory {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:kemoazserver.database.windows.net,1433;Initial Catalog=p0_mysql;Persist Security Info=False;"
            + "User ID=kemoallen;Password=Sholos_03;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        
    }
}