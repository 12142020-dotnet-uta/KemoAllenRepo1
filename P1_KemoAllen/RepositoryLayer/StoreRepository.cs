using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace RepositoryLayer
{
    public class StoreRepository
    {
        public StoreRepository()
        {
        }

        private readonly ILogger<StoreRepository> _logger;
        private readonly Store_DbContext _storeDbContext;

        DbSet<Customer> customers;
        DbSet<Location> locations;
        DbSet<Order> orders;
        DbSet<Inventory> inventories;
        DbSet<Product> products;

        public Customer LoginCustomer(Customer customer)
        {

        }

        public Customer GetCustomerById(Guid customerId)
        {

        }

        public Player EditPlayer(Customer customer)
        {

        }
    }
}
