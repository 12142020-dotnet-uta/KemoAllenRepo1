using System;
using System.Collections.Generic;
using System.Linq;

namespace P0_KemoAllen
{
    class Program
    {
        //static StoreRepositoryLayer storeContext = new StoreRepositoryLayer(); //Create context so that methods can access it
        static List<Customer> customers = new List<Customer>();
        static List<Location> locations = new List<Location>();
        static List<Order> orders = new List<Order>();
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tWelcome to AllenCo!");

            string logInChoice = "y"; //The program starts by default
            string [] userName;
            Customer user = new Customer();
            do
            {
                Console.WriteLine("Would you like to Log in?");
                logInChoice = Console.ReadLine();
                if(logInChoice == "y")
                {
                Console.WriteLine("\tThis is the Log-in screen");
                Console.WriteLine("Please enter your first and last name. If they are unique a new user will be added");
                userName = RetrieveUser();
                user = LogIn(userName);
                MainMenu(user);
                }
                Console.WriteLine("Would you like to continue?");
                logInChoice = Console.ReadLine();
            }while(logInChoice == "y");

        }//main

        public static string[] RetrieveUser() //Logs in or creates a new user.
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

        public static Customer LogIn(string [] userName) 
        {
            Customer user = new Customer();
            bool customerFound = false;

            foreach(var item in customers)
            {
                if(item.FirstName.Equals(userName[0]))
                {
                    if(item.LastName.Equals(userName[1]))
                    {
                        user = item;
                        customerFound = true;
                        //Console.WriteLine("Old User " + user.FirstName);
                        break;
                    }
                }

            }

            if(!customerFound)
            {
                user.FirstName = userName[0];
                user.LastName = userName[1];

                customers.Add(user);
                //Console.WriteLine("New User "+ user.FirstName);
            }

            return user;
        }

        public static Location SelectLocation(){
            string locName;
            bool locationFound = false;
            Location loc = new Location();
            //Inventory inv = new Inventory();

            Console.WriteLine("Which location are you ordering from?");
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
                loc.LocationInventory = new Inventory();
                loc.LocationInventory.LoadProducts();
                locations.Add(loc);
            }
            
            //Console.WriteLine(loc.LocationInventory.OrderProduct(1).ToString());

            return loc;
        }

        public static void MainMenu(Customer user) //Manages all of the options for the user in the main menu
        { 
            String menuChoice = "";
            Guid id = new Guid();
            //Order order;
            //Location location;
            bool cont = true; 
            
            do
            {
                Console.WriteLine($"Hello {user.FirstName} What would you like to do?");
                Console.WriteLine("\tThe Menu options are:\n\torder - To make a new order\n\td1 - Display a customer's order history"
                +"\n\td2 - Display a location's order history\n\t search - To lookup a customer\n\t d3 - Display an order's content\n\t q - Quit");
                menuChoice = Console.ReadLine();

                //user portal
                switch(menuChoice)
                {
                case "order":
                EditOrder(user); //adds or remove items from an order list
                break;
                case "d3": //Displays an order's details
                DisplayOrder(id);
                break;
                case "d1"://shows all customer order information history 
                DisplayCustomerHistory();
                break;
                case "d2"://shows the order history of a store
                DisplayLoctionHistory();
                break;
                case "search"://searches for other customers by name
                SearchUser();
                break;
                default:
                cont = false;
                break;
                }
            }while(cont);
        }//MainMenu

        public static void EditOrder(Customer user){ //Ask for continue. Display order after finish
            Order order = new Order();
            int itemNumber, numOfItem;
            bool validNumber = false;
            string consoleInput;
            //Location loc = SelectLocation();
            //Inventory inv = new Inventory();
            Product prod;
            //Guid guid;

            //Add the customer to the order
            order.OrderCustomer = user;
            //Get the location for the order
            order.OrderLocation = SelectLocation();

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
                prod = order.OrderLocation.LocationInventory.OrderProduct(itemNumber, numOfItem);
                //Add to the order
                order.AddToOrder(prod);
                Console.WriteLine("Would you like to continue your order?");
                consoleInput = Console.ReadLine(); 

            }while(consoleInput != "no" && consoleInput != "n");
            //Console.WriteLine(prod.ToString());
            orders.Add(order);
            //Display current receipt
            DisplayOrder(order.OrderId);
            

        }//EditOrder

        public static void DisplayCustomerHistory(){
            string[] customerName;
            Customer cust = new Customer();
            bool customerFound = false;

            Console.WriteLine("Which customer's order history would you like to see?");
            customerName = RetrieveUser();

            foreach(var item in customers)
            {
                if(item.FirstName.Equals(customerName[0]))
                {
                    if(item.LastName.Equals(customerName[1]))
                    {
                        cust = item;
                        customerFound = true;
                        break;
                    }
                }

            }

            if(customerFound)
            {
                foreach(var order in orders)
                {
                    if(order.OrderCustomer.UserId == cust.UserId)
                    {
                        order.DisplayDetails();
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry we couldn't find that customer.");
            }

        }//DisplayOrder

        public static void DisplayOrder(Guid id)
        {
            bool orderFound = false;
            Order order = new Order();

            // if(id == null) //Always false? Remove
            // {
            // Console.WriteLine("Please enter the order id");
            // //Get order id

            // }

            foreach(var item in orders)
            {
                if(item.OrderId == id)
                {
                    order = item;
                    orderFound = true;
                    break;
                }
            }

            if(orderFound)
            {
                order.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Sorry we couldn't find that order.");
            }
        }//Display Order
        public static void DisplayLoctionHistory()
        {
            //bool locationFound = false;
            Location loc = new Location();
            String locName;

            Console.WriteLine("What is the name of the location.");
            locName = Console.ReadLine();

            // foreach(var item in locations)
            // {
            //     if(item.LocationName.Equals(locName))
            //     {
            //         Console.WriteLine("Location found.");   
            //         loc = item;
            //         locationFound = true;
            //         break;
            //     }
            // }

            //if(locationFound)
            //{
                foreach(var order in orders)
                {
                    if(order.OrderLocation.LocationName == locName)
                    {
                        order.DisplayDetails();
                        //break;
                    }
                }
            //}
        }
        public static void SearchUser()
        {
            string [] userSearch;
            bool custFound = false;
            Guid id = new Guid();

            Console.WriteLine("Who are you looking for?");
            userSearch = RetrieveUser();

            foreach(var cust in customers)
            {
                if(cust.FirstName == userSearch[0])
                {
                    if(cust.LastName == userSearch[1])
                    {
                        id = cust.UserId;
                        custFound = true;
                        break;
                    }
                }
            }

            if(custFound)
            {
                Console.WriteLine(userSearch[0] + "'s user id is: " + id);
            }

        }

    }//class
}//namespace
