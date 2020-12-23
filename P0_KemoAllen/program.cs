using System;
using System.Collections.Generic;
using System.Linq;

namespace P0_KemoAllen
{
    class Program
    {
        static StoreRepositoryLayer storeContext = new StoreRepositoryLayer(); //Create context so that methods can access it
        int numberOfProducts = Enum.GetNames(typeof(ProductList)).Length; //Gets the number of products in the product list
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AllenCo!");

            string logInChoice = "y";
            do
            {
                MainMenu();

                Console.WriteLine("Would you like to continue?");
                logInChoice = Console.ReadLine();
            }while(logInChoice == "y");

        }//main

        public static void MainMenu() //Manages all of the options for the user in the main menu
        { 
            String menuChoice = "";
            
            Console.WriteLine("What would you like to do?");
            menuChoice = Console.ReadLine();

            switch(menuChoice){
                default:
                break;
            }
        }//MainMenu
    }//class
}//namespace
