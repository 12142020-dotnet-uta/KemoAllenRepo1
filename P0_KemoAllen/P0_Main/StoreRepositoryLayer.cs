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
        public string[] GetFirstAndLastName() 
        {
            string[] names;
            bool nameValid = false;

            Console.WriteLine("Please enter your first and last name.");

            do
            {
                names = Console.ReadLine().Trim().Split(' ');

                if(names.Length != 2)      
                {
                    Console.WriteLine("Sorry the name that you entered was invalid. Please try again.");
                    nameValid = false;
                }   
                else
                    nameValid = true;   

            }while(!nameValid);

            return names;
        }//GetFirstAndLastName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CheckUserName()
        {
            string userName;
            bool valid = false;

            do
            {
                userName = Console.ReadLine().Trim();
                //If userName has a value return true
                if(!userName.equals(""))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Sorry the name you entered wasn't valid try again.");
                }
            }while(!valid);

            return userName;

        }
        /// <summary>
        /// Asks for the user to enter their user name. If that user is already registed return that user.
        /// If the user is not registered then add the new user and ask for their credentials.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> Customer Object</returns>
        public Customer LogIn() 
        {
            string userName;
            string [] actualName;
            Customer user = new Customer();

            Console.WriteLine("Please enter your user name.");
            userName = CheckUserName();

            //Console.WriteLine(userName[0] + userName[1]);
            user = customers.Where(x => x.UserName == userName).FirstOrDefault();

            if(user == null)
            {
                actualName = GetFirstAndLastName();
                user = new Customer(actualName[0], actualName[1], userName);
                customers.Add(user);
                DbContext.SaveChanges();
            }

            return user;
        }
        /// <summary>
        /// First asks for a locations name. Then either creates a new location
        ///  or returns a matching loaction.
        /// </summary>
        /// <returns>Location Object</returns>
        public Location SelectLocation()
        {
            string locName;
            bool locationFound = false;
            Location loc = new Location();
            //Inventory inv = new Inventory();

            Console.WriteLine("Which location are you ordering from? " +
            "If the name you input is not here a new locaiton wil be added.");
            foreach (var item in locations)
            {
                Console.WriteLine("\t" + item.locationName);   
            }
            

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
        public Guid EditOrder(Customer user)
        { 
            Order order = new Order();
            int itemNumber, numOfItem;
            //bool validNumber = false;
            //string consoleInput;
            Product prod;

            //Add the customer to the order
            order.orderCustomer = user;
            //Get the location for the order
            order.orderLocation = SelectLocation();

            do
            {
                //Get item number and check if it is valid
                Console.WriteLine("What would you like to add to the order?");
                itemNumber = ParseCheckInt();
            
                //Get quantity of item and check if it is valid
                Console.WriteLine("How many would you like to order?");
                numOfItem = ParseCheckInt();
                
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
                Console.WriteLine("Would you like to continue your order? (y/n)");
                consoleInput = Console.ReadLine(); 

            }while(consoleInput != "no" && consoleInput != "n");
            //Console.WriteLine(prod.ToString());
            orders.Add(order);
            DbContext.SaveChanges();
            //Display current receipt
            //DisplayOrder(order.orderId);
            return order.orderId;
        }//EditOrder

        /// <summary>
        /// This method takes a user input and tries to parse it to an int.
        /// If the int was invalid the user will be prompted to enter a value again.
        /// </summary>
        /// <returns></returns>
        public int ParseCheckInt()
        {
            bool validNumber = false;
            String input;
            int output;

            do
            {
                consoleInput = Console.ReadLine();
                validNumber = int.TryParse(input, out output);
                    if(!validNumber)
                        {   
                        Console.WriteLine("The number that you entered was invalid. Try again.");
                        }
            } while (!validNumber);

            return output;
        }//ParseCheckInt

        /// <summary>
        /// 
        /// </summary>
        public void DisplayAvailableLocations()
        {
            foreach(var location in locations)
            {
                location.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void DisplayAvailableProducts()
        {
            foreach(var product in products)
            {
                product.ToString();
            }
        }
        public void DisplayAvailableCustomers()
        {
            foreach(var customer in customers)
            {
                customer.ToString();
            }
        }
        
    }
}