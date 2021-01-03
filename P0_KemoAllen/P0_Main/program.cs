using System;
using System.Collections.Generic;
using System.Linq;

namespace P0_KemoAllen
{
    class Program
    {
        static Store_DbContext sDbC = new Store_DbContext();
        static StoreRepositoryLayer storeContext = new StoreRepositoryLayer(sDbC); //Create context so that methods can access it
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tWelcome to AllenCo!");

            string logInChoice = "y"; //The program starts by default
            //string [] userName;
            Customer user = new Customer();
            do
            {
                Console.WriteLine("Would you like to Log in? (y/n)");
                logInChoice = Console.ReadLine();
                if(logInChoice == "y")
                {
                Console.WriteLine("\tThis is the Log-in screen");
                user = storeContext.LogIn();
                MainMenu(user);
                }
                Console.WriteLine("Would you like to continue? (y/n)");
                logInChoice = Console.ReadLine();
            }while(logInChoice == "y");

        }//main
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
                +"\n\td2 - Display a location's order history\n\tsearch - To lookup a customer\n\td3 - Display an order's content\n\tq - Quit");
                menuChoice = Console.ReadLine();

                //user portal
                switch(menuChoice)
                {
                case "order":
                id = storeContext.EditOrder(user); //adds or remove items from an order list
                DisplayOrder(id);
                break;
                case "d3": //Displays an order's details
                Console.WriteLine("Please enter the order id.");
                id = Guid.Parse(Console.ReadLine());
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
        public static void DisplayCustomerHistory()
        {
            string customerName;
            Customer cust = new Customer();
            bool customerFound = false;

            Console.WriteLine("Which customer's order history would you like to see?");
            customerName = storeContext.CheckUserName();

            List<Customer> customers = storeContext.GetCustomers();
            List<Order> orders = storeContext.GetOrders();

            foreach(var item in customers)
            {
                if(item.UserName.Equals(customerName))
                {
                    cust = item;
                    customerFound = true;
                    break; 
                }

            }

            if(customerFound)
            {
                foreach(var order in orders)
                {
                    if(order.orderCustomer.userId == cust.userId)
                    {
                        order.DisplayDetails();
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry we couldn't find that customer.");
            }

        }//DisplayCustomerHistory

        public static void DisplayOrder(Guid id)
        {
            bool orderFound = false;
            Order order = new Order();

            List<Order> orders = storeContext.GetOrders();

            foreach(var item in orders)
            {
                if(item.orderId == id)
                {
                    order = item;
                    orderFound = true;
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
            //Location loc = new Location();
            String locName;
            bool locationFound = false;

            Console.WriteLine("Which location would you like to see?");
            storeContext.DisplayAvailableLocations();
            locName = Console.ReadLine();

            List<Order> orders = storeContext.GetOrders();

            //Print orders with matching location names 
            foreach(var order in orders)
            {
                if(order.orderLocation.LocationName == locName)
                 {
                     order.DisplayDetails();
                 }
            }

            if(!locationFound)
            {
                Console.WriteLine("Sorry we could't find that location.");
            }
            
        }//DisplayLoctionHistory
        public static void SearchUser()
        {
            string userSearch;
            bool custFound = false;
            Customer user = new Customer();

            Console.WriteLine("Which user are you looking for? (Enter user name)");
            userSearch = storeContext.CheckUserName();

            List<Customer> customers = storeContext.GetCustomers();

            foreach(var cust in customers)
            {
                if(cust.UserName == userSearch)
                {
                    user = cust;
                    custFound = true;
                    break;       
                }
            }

            if(custFound)
            {
                Console.WriteLine(user.UserName + "'s user id is: " + user.userId);
            }

        }//SearchUser

    }//class
}//namespace
