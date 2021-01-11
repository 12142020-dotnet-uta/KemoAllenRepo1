using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public class StoreRepository
    {
        DbSet<Customer> customers;
        DbSet<Location> locations;
        DbSet<Order> orders;
        DbSet<Inventory> inventories;
        DbSet<Product> products;

        private readonly ILogger<StoreRepository> _logger;
        private readonly Store_DbContext _storeDbContext;

        public StoreRepository()
        {
        }

        public StoreRepository(Store_DbContext dbContext, ILogger<StoreRepository> logger)
        {
            _storeDbContext = dbContext;
            this.customers = dbContext.customers;
            this.locations = dbContext.locations;
            this.orders = dbContext.orders;
            this.inventories = dbContext.inventories;
            this.products = dbContext.products;
            _logger = logger;

        }
        /// <summary>
        /// Checks to see if a user with the same username already exists.
        /// If the username is not unique, registration will be rejected.
        /// If it is unique then a new user will be added.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer RegisterCustomer(Customer customer)
        {
            bool customerAlreadyExists = customers.Any(x => x.UserName == customer.UserName);
            Customer customer1 = null;

            if (!customerAlreadyExists)
            {
                customer1 = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    UserName = customer.UserName,
                    Password = customer.Password
                };
                customers.Add(customer1);
                _storeDbContext.SaveChanges();

                try
                {
                    Customer customer2 = customers.FirstOrDefault(x => x.userId == customer1.userId);
                    return customer2;
                }
                catch (ArgumentNullException E)
                {
                    _logger.LogInformation($"There was a problem with adding the user to the db, {E}");
                }

            }
            else
            {
                //Error message
            }

            return customer1;
        }

        public Customer LoginCustomer(Customer customer)
        {
            Customer customer1 = customers.FirstOrDefault(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName);

            if(customer1 == null)
            {
                //Error message

            }

            return customer1;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            Customer customer = customers.FirstOrDefault(x => x.userId == customerId);
            return customer;
        }

        /// <summary>
        /// Takes in a customer, changes their parameters and save it to the db
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer EditCustomer(Customer customer)
        {
            //Search Db for customer
            Customer customer1 = GetCustomerById(customer.userId);

            //transfer over new values
            customer1.FirstName = customer.FirstName;
            customer1.LastName = customer.LastName;
            customer1.UserName = customer.UserName;
            //other stuff
            _storeDbContext.SaveChanges();

            //check if they were added
            Customer customer2 = GetCustomerById(customer.userId);

            return customer2;

        }

        /// <summary>
        /// Gets a location from the database
        /// </summary>
        /// <returns>Location</returns>
        public Location SelectLocation(string locName)
        {
            Location loc = null;
            bool locationFound = false;

            //Message to user
            //DisplayAvailableLocations();

            //get from web page
            //locName = Console.ReadLine();

            //drop down for locations
            //make a view for locations
            foreach (var location in locations)
            {
                if (location.LocationName.Equals(locName))
                {
                    loc = location;
                    locationFound = true;
                    break;
                }
            }

            if (!locationFound)
            {
                //Error couldn't find location in db

            }

            return loc;
        }

        /// <summary>
        /// Sends completed orders to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="location"></param>
        public void MakeAnOrder(Customer customer, Location location)
        {
            //ViewModel for data from webpage. Pass into here
            Guid id = Guid.NewGuid();
            int numOfItem;
            Inventory inv;
            Location loc;
            bool quantityIsAvailable;

        }

        /// <summary>
        /// Gets an inventory item from the database
        /// </summary>
        /// <returns></returns>
        public Inventory GetInventoryProduct()
        {
            Inventory inv = null;

            return inv;
        }

        /// <summary>
        /// Checks if the quantity that the user asks for is available or not.
        /// And also prevents the user from taking too many items at once.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfQuantityAvailable()
        {
            bool available = false;
            //Prevent user form ordering too much multiple times
            return available;
        }

        /// <summary>
        /// Searches 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Inventory SearchForInventoryProduct(String itemName, Location location)
        {
            Inventory inv = null;

            return inv;
        }

        /// <summary>
        /// Searches for orders with a matching GUid id then totals their prices.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Total price of an order</returns>
        public decimal GetTotalPrice(Guid orderId)
        {
            decimal total = 0;
            foreach (var item in orders)
            {
                if (item.orderId == orderId)
                {
                    total += item.getPrice();
                }
            }
            return total;
        }
        /// <summary>
        /// Returns matching all objects in List<Customer>
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            return customers.ToList();
        }
        /// <summary>
        /// Returns matching all objects in List<Order>
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            return orders.ToList();
        }
        /// <summary>
        /// Returns matching all objects in List<Location>
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return locations.ToList();
        }
        /// <summary>
        /// Returns matching all objects in List<Product>
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return products.ToList();
        }

        /// <summary>
        /// Takes a customer guid and removes the matching customer from the db.
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns>True if the matching customer was deleted</returns>
        public bool DeleteCustomerById(Guid customerGuid)
        {
            Customer customer = customers.FirstOrDefault(x => x.userId == customerGuid);
            var success = customers.Remove(customer);
            _storeDbContext.SaveChanges();

            if(success != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckUserExists(Guid userGuid)
        {
            bool exists = customers.Any(x => x.userId == userGuid);

            return exists;
        }



    }
}
