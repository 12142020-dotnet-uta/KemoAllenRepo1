using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Inventory
    {
        public Inventory(){

        }
        public Dictionary<int, Product> ProductsList = new Dictionary<int, Product>();

        [Key]
        /// <summary>
        /// The id of the inventory.
        /// </summary>
        /// <returns>Guid</returns>
        public Guid inventoryId {get; set;} = new Guid();
        
        /// <summary>
        /// This function takes a Product object and adds it to the Inventory.
        /// If an item with the same key already exists the new one will be rejected.
        /// </summary>
        /// <param name="p"></param>
        public void AddNewProduct(int productId, Product p){
            bool uniqueProduct = false;

            uniqueProduct = ProductsList.TryAdd(productId, p);

            if(uniqueProduct)
            {
                ProductsList.Add(productId, p);   
            }
            else
            {
                Console.WriteLine("There was an issue with adding that product. Maybe the key isn't unique.");
            }
        
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

        
        /// <summary>
        /// Retrieves a product based on the given int id and quantity desired.
        /// A new Product object with quantity set to the accepted quantity taken.
        /// </summary>
        /// <param name="itemToOrder"></param>
        /// <param name="numOfItem"></param>
        /// <returns>A product with an altered quantity</returns>
        public Product OrderProduct(int itemToOrder, int numOfItem)
        {   
            int quantityUsed;
            Product orderedProduct = new Product();

            Product p = FindProduct(itemToOrder);

            quantityUsed = DecrementQuantity(p, numOfItem);

            //Set price of the shipment to the unit price
            orderedProduct.price = p.price;
            //Give the shipment the same description as the base product
            orderedProduct.description = p.description;
            //Set the quantity of the shipment to how many items were able to be ordered
            orderedProduct.quantity = quantityUsed;

            return orderedProduct;
        }
        /// <summary>
        /// Searches for a product based on the given int id.
        /// </summary>
        /// <param name="itemToOrder"></param>
        /// <returns>The Product of Key value</returns>
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
            Console.WriteLine("Items ordered " + numOfItem);
            Console.WriteLine("Quantity available " + p.Quantity);

            //Check if the Product requested exists
            if(p != null)
            {
                //Check if the quantity is available
                if(p.quantity > 0)
                {
                    if(numOfItem >= 10)
                    {
                        if(p.quantity < numOfItem)
                        {
                            // Console.WriteLine("Sorry the amount requested is greater than what is available.");
                            // numTaken = 0;
                            numberTaken = p.quantity;
                            p.quantity -= p.quantity;
                        }
                        else
                        {
                            numberTaken = 10;
                            p.quantity -= 10;
                        }
                        
                    }
                    else if(numOfItem > 0)
                    {
                        if(p.quantity < numOfItem)
                        {
                            // Console.WriteLine("Sorry the amount requested is greater than what is available.");
                            // numTaken = 0;
                            numberTaken = p.quantity;
                            p.quantity -= p.quantity;
                        }
                        else
                        {
                            numberTaken = numOfItem;
                            p.quantity -= numOfItem;
                        }
                    }
                }
                
            }
            Console.WriteLine("Quantity now " + p.Quantity);
            return numberTaken;
        }
    }//Inventory
}//namespace