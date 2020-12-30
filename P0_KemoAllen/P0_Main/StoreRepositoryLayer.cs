using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace P0_KemoAllen
{
    public class StoreRepositoryLayer
    {
        // int numberOfProducts = Enum.GetNames(typeof(ProductList)).Length; //Gets the number of products in the product list
        Store_DbContext DbContext = new Store_DbContext();
        DbSet<Product> products; //Database set of products
        DbSet<Customer> customers; //Database set of customers
        DbSet<Order> orders; //Database set of orders
        DbSet<Location> locations; //Database set of locations
        DbSet<Inventory> inventory;

        public StoreRepositoryLayer()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public StoreRepositoryLayer(Store_DbContext context)
        {
            this.DbContext = context;
            customers = DbContext.customers;
            orders = DbContext.orders;
            locations = DbContext.locations;
            inventory = DbContext.inventory;
            products = DbContext.products;
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
        // public void AddListItemsToDB()
        // {
        //     foreach(var item in list)
        //     {

        //     }
        // }
        /// <summary>
        /// Converts name input into a 2 element string array
        /// </summary>
        /// <returns></returns>
        public string[] RetrieveUser() 
        {
            string[] userName;
            bool nameValid = false;

            do
            {
                userName = Console.ReadLine().Trim().Split(' ');

                if(userName.Length != 2)      
                {
                    Console.WriteLine("Sorry the name that you entered was invalid. Please try again.");
                    nameValid = false;
                }   
                else
                    nameValid = true;   

            }while(!nameValid);

            return userName;
        }//LogIn
        /// <summary>
        /// Takes in a 2 element array containing a user's first and last names.
        /// Then either adds a new customer or gets an old customer from the list.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> Customer Object</returns>
        public Customer LogIn(string [] userName) 
        {
            Customer user = new Customer();
            //Console.WriteLine(userName[0] + userName[1]);
            user = customers.Where(x => x.FirstName == userName[0] && x.LastName == userName[1]).FirstOrDefault();

            if(user == null)
            {
                user = new Customer(userName[0], userName[1]);
                customers.Add(user);
                DbContext.SaveChanges();
            }

            // bool customerFound = false;

            // foreach(var item in customers)
            // {
            //     if(item.FirstName.Equals(userName[0]))
            //     {
            //         if(item.LastName.Equals(userName[1]))
            //         {
            //             user = item;
            //             customerFound = true;
            //             //Console.WriteLine("Old User " + user.FirstName);
            //             break;
            //         }
            //     }

            // }

            // if(!customerFound)
            // {
            //     user.FirstName = userName[0];
            //     user.LastName = userName[1];

            //     customers.Add(user);
            //     DbContext.SaveChanges();
            //     //Console.WriteLine("New User "+ user.FirstName);
            // }

            return user;
        }
        /// <summary>
        /// First asks for a locations name. Then either creates a new location
        ///  or returns a matching loaction.
        /// </summary>
        /// <returns>Location Object</returns>
        public Location SelectLocation(){
            string locName;
            bool locationFound = false;
            Location loc = new Location();
            //Inventory inv = new Inventory();

            Console.WriteLine("Which location are you ordering from?");
            locName = Console.ReadLine();

            foreach(var item in locations)
            {
                if(item.locationName.Equals(locName))
                {
                    loc = item;
                    locationFound = true;
                    break;
                }
            }

            if(!locationFound) 
            {           
                loc.locationName = locName;
                loc.locationInventory = new Inventory();
                loc.locationInventory.LoadProducts();
                locations.Add(loc);
                DbContext.SaveChanges();
            }
            
            //Console.WriteLine(loc.LocationInventory.OrderProduct(1).ToString());

            return loc;
        }
        /// <summary>
        /// Takes a Customer, then asks them for a location.
        /// Afterwards asks for an item and a quantity of that item.
        /// </summary>
        /// <param name="user"></param>
        public Guid EditOrder(Customer user){ 
            Order order = new Order();
            int itemNumber, numOfItem;
            bool validNumber = false;
            string consoleInput;
            //Location loc = SelectLocation();
            //Inventory inv = new Inventory();
            Product prod;
            //Guid guid;

            //Add the customer to the order
            order.orderCustomer = user;
            //Get the location for the order
            order.orderLocation = SelectLocation();

            do
            {
                //Get item number and check if it is valid
                do
                {
                    Console.WriteLine("What would you like to add to the order?");
                    consoleInput = Console.ReadLine();
                    validNumber = int.TryParse(consoleInput, out itemNumber);
                    if(!validNumber)
                        {   
                        Console.WriteLine("The number that you entered was invalid.");
                        }

                }while(!validNumber); 
                //Get quantity of item and check if it is valid
                validNumber = false;
                do
                {

                    Console.WriteLine("How many would you like to order?");
                    consoleInput = Console.ReadLine();
                    validNumber = int.TryParse(consoleInput, out numOfItem);
                    if(!validNumber)
                        {   
                        Console.WriteLine("The number that you entered was invalid.");
                        }
                }while(!validNumber);
                
                //Get the item requested
                prod = order.orderLocation.locationInventory.OrderProduct(itemNumber, numOfItem);
                //Add product to list
                if(prod.quantity > 0)
                {
                products.Add(prod);
                DbContext.SaveChanges();
                //Add to the order
                order.AddToOrder(prod);
                DbContext.SaveChanges();
                }
                Console.WriteLine("Would you like to continue your order?");
                consoleInput = Console.ReadLine(); 

            }while(consoleInput != "no" && consoleInput != "n");
            //Console.WriteLine(prod.ToString());
            orders.Add(order);
            DbContext.SaveChanges();
            //Display current receipt
            //DisplayOrder(order.orderId);
            return order.orderId;
        }//EditOrder
        
    }
}