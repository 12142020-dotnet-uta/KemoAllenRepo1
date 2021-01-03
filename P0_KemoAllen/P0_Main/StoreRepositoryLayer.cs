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
        DbSet<Inventory> inventories;

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
            inventories = DbContext.inventories;
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
        /// <summary>
        /// Returns matching all objects in List<Product>
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return products.ToList();
        }
        /// <summary>
        /// Loads an initial list of items to DB
        /// </summary>
        public void AddListItemsToDB()
        {
            //use one strings and one object
            Product apple = new Product("Apple", 0.29);
            products.Add(apple);
            Product water = new Product("Water", 0.49);
            products.Add(water);
            Product cookie = new Product("Cookies", 2.99);
            products.Add(cookie);
            Product milk = new Product("Milk", 2.49);
            products.Add(milk);
            Product cabbage = new Product("Cabbage", 1.39);
            products.Add(cabbage);
            Product rice = new Product("Rice", 6.99);
            products.Add(rice);

            DbContext.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadItemsToInventory()
        {
            // foreach (var product in products)
            // {
                
            // }
        }
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
                if(!userName.Equals(""))
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
            DisplayAvailableLocations(); 

            locName = Console.ReadLine();

            foreach(var item in locations)
            {
                if(item.LocationName.Equals(locName))
                {
                    loc = item;
                    locationFound = true;
                    break;
                }
            }

            if(!locationFound) 
            {           
                loc.LocationName = locName;
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
            int numOfItem;
            string consoleInput;
            //Product prod, orderProd;
            Inventory inv;
            bool quantityAvailable;

            //Add the customer to the order
            order.orderCustomer = user;
            //Get the location for the order
            order.orderLocation = SelectLocation();
            //Get the location's inventory
            //inv = order.orderLocation.locationInventory;

            do
            {
                //Get item name and check if it is valid
                Console.WriteLine("What would you like to add to the order?");
                DisplayAvailableProducts();
                inv = FindProduct(order.orderLocation);
            
                //Get quantity of item and check if it is valid
                Console.WriteLine("How many would you like to order?");
                numOfItem = ParseCheckInt();
                //Get the item requested
                quantityAvailable = CheckIfQuantityAvailable(inv, numOfItem);
                 //Add to the order and add order to DB
                if(quantityAvailable)
                {
                    TakeFromInventoryAddToOrder(inv, numOfItem, order);
                }

                Console.WriteLine("Would you like to continue your order? (y/n)");
                consoleInput = Console.ReadLine(); 

            }while(consoleInput != "no" && consoleInput != "n");
            
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
            String consoleInput;
            int output;

            do
            {
                consoleInput = Console.ReadLine();
                validNumber = int.TryParse(consoleInput, out output);
                    if(!validNumber)
                        {   
                        Console.WriteLine("The number that you entered was invalid. Try again.");
                        }
            } while (!validNumber);

            return output;
        }//ParseCheckInt
        /// <summary>
        /// Searches for a product based on the given string.
        /// </summary>
        /// <returns>A copy of the desired item.</returns>
        public Inventory FindProduct(Location loc)
        {
            Inventory inv;
            bool itemExists = false;
            string prodName;
            
            //Check to see if the there is an item for the string passed
            do
            {
                //Get user input
                prodName = Console.ReadLine();
                //Get the matching product from the inventory
                inv = GetInvetoryItem(prodName, loc);

                if(inv != null)
                {
                    itemExists = true;
                    Console.WriteLine($"There are {inv.inventoryQuantity} {inv.inventoryProduct.Description}'s in stock.");
                }
                
                if(!itemExists)
                {
                    Console.WriteLine("No associated item for " + prodName + " was found. Please try again.");
                }
            } while (!itemExists);

            return inv;
        }
        /// <summary>
        /// Checks if it is possible to take the requested quantity away from the inventory.
        /// Returns false if the input is too great for the current quantity.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="numOfItem"></param>
        public bool CheckIfQuantityAvailable(Inventory inv, int numOfItem)
        {
            bool quantityAvailable = false;
            Product orderP = new Product();

            //Check if the Product requested exists
            if(inv != null)
            {
                //Check if the quantity is available
                if(inv.inventoryQuantity > 0)
                {
                    if(numOfItem > 10)
                    {
                        Console.WriteLine("Sorry. You asked for " + numOfItem + $" {inv.inventoryProduct.Description}(s), but the limit is 10.");
                        
                    }
                    else if(numOfItem > 0)
                    {
                        if(inv.inventoryQuantity < numOfItem)
                        {
                            Console.WriteLine("Sorry. You asked for " + numOfItem + $" {inv.inventoryProduct.Description}(s),"
                             + $" but there is only {inv.inventoryQuantity} left.");
                        }
                        else
                        {
                            quantityAvailable = true;

                        }
                    }
                }
                
            }
                        
            return quantityAvailable;
        }
        /// <summary>
        /// Decrements the quantity from the inventory and adds the amount take to the order
        /// and adds the Product to the order.
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="numOfItem"></param>
        /// <param name="orderP"></param>
        public void TakeFromInventoryAddToOrder(Inventory inv, int numOfItem, Order orderP)
        {
            //Decrement from the main product
            inv.inventoryQuantity -= numOfItem;
            Console.WriteLine($"Success! The quantity of {inv.inventoryProduct.Description} is now {inv.inventoryQuantity}.");
            //Copy information into the order product
            orderP.orderProduct = inv.inventoryProduct;
            orderP.orderQuantity = inv.inventoryQuantity;
            //Add to the list of orders
            orders.Add(orderP);
            //Update DB
            DbContext.SaveChanges();
        }
        /// <summary>
        /// Takes in the location and name of the desired item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="loc"></param>
        /// <returns>The inventory product that matches the two inputs.</returns>
        public Inventory GetInvetoryItem(String itemName, Location loc)
        {
            Inventory inv = new Inventory();
            foreach(var inventory in inventories)
            {
                if(loc.locationInventory == inventory)
                {
                    if(inventory.inventoryProduct.Description == itemName)
                    {
                        inv = inventory;
                        break;
                    }
                }
            }
            return inv;
        }
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
        /// <summary>
        /// 
        /// </summary>
        public void DisplayAvailableCustomers()
        {
            foreach(var customer in customers)
            {
                customer.ToString();
            }
        }
        
    }
}