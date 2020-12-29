using System;
using System.Collections.Generic;
namespace P0_KemoAllen
{
    public class Inventory
    {
        public Inventory(){

        }
        public Dictionary<int, Product> ProductsList = new Dictionary<int, Product>();
        
        /// <summary>
        /// This function takes a Product object and adds it to the Inventory.
        /// If an item with the same description already exists the new one will be rejected.
        /// </summary>
        /// <param name="p"></param>
        public void AddNewProduct(Product p){
        
        }
        /// <summary>
        /// This function loads a present list of products to the Inventory.
        /// </summary>
        public void LoadProducts(){ 
             Product apple = new Product("Apple", 0.29, 100);
             ProductsList.Add(0, apple);
             Product water = new Product("Bottle of Water", 0.49, 100);
             ProductsList.Add(1, water);
             Product oreo = new Product("Oreo Cookies", 2.99, 100);
             ProductsList.Add(2, oreo);
             Product milk = new Product("Gallon of Milk", 2.49, 100);
             ProductsList.Add(3, milk);
             Product cabbage = new Product("Head of Cabbage", 1.39, 100);
             ProductsList.Add(4, cabbage);
             Product rice = new Product("Bag of Rice", 6.99, 100);
             ProductsList.Add(5, rice);

        }

        public Product OrderProduct(int itemToOrder, int numOfItem)
        {   
            int quantityUsed;
            Product orderedProduct = new Product();

            Product p = FindProduct(itemToOrder);

            quantityUsed = DecrementQuantity(p, numOfItem);

            //Set price of the shipment to the unit price
            orderedProduct.Price = p.Price;
            //Give the shipment the same description as the base product
            orderedProduct.Description = p.Description;
            //Set the quantity of the shipment to how many items were able to be ordered
            orderedProduct.Quantity = quantityUsed;

            return orderedProduct;
        }

        public Product FindProduct(int itemToOrder)
        {
            Product p = new Product();
            int num;
            bool itemExists = false;

            //Check to see if the there is an item for the number passed
            foreach(var item in ProductsList)
            {
                num = item.Key;
                if(num == itemToOrder){
                    itemExists = true;
                    break;
                }
               
            }

            if(!itemExists)
            {
                Console.WriteLine("No associated item for " + itemToOrder + " was found.");
            }
            else
            {
                p = ProductsList[itemToOrder];
            }

            return p;
        }
        /// <summary>
        /// Decrements the Quantity of a Product by the number passed in.
        /// The maximum number of items that can be taken at once is ten.
        /// If the Quantity requested is greater than what is avaialbe then the remaining quantity will be sent.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="numOfItem"></param>
        public int DecrementQuantity(Product p, int numOfItem)
        {
            int numberTaken = 0;
            //Console.WriteLine("Items ordered " + numOfItem);
            //Console.WriteLine("Quantity" + p.Quantity);

            //Check if the Product requested exists
            if(p != null)
            {
                //Check if the quantity is available
                if(p.Quantity > 0)
                {
                    if(numOfItem >= 10)
                    {
                        if(p.Quantity < numOfItem)
                        {
                            numberTaken = p.Quantity;
                            p.Quantity -= p.Quantity;
                        }
                        else
                        {
                            numberTaken = 10;
                            p.Quantity -= 10;
                        }
                        
                    }
                    else if(numOfItem > 0)
                    {
                        if(p.Quantity < numOfItem)
                        {
                            numberTaken = p.Quantity;
                            p.Quantity -= p.Quantity;
                        }
                        else
                        {
                            numberTaken = numOfItem;
                            p.Quantity -= numOfItem;
                        }
                    }
                }
                
            }
        //Console.WriteLine("Quantity now " + p.Quantity);
            return numberTaken;
        }
    }//Inventory
}//namespace