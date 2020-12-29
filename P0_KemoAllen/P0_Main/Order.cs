using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Order
    {
        public Order(){
            timeCreated = DateTime.Now;

        }

        //Order id
        [Key]
        public Guid orderId { get; set;} = Guid.NewGuid();
        // public Guid OrderId
        // {
        //     get { return orderId; }
        //     set { orderId = value; }
        // }

        //List containing the products in an order
        public List<Product> orderProducts = new List<Product>();

        public void AddToOrder(Product p)
        {
            orderProducts.Add(p);
        }
        
        //The order's store location
        public Location orderLocation { get; set;}
        // public Location OrderLocation
        // {
        //     get { return orderLocation; }
        //     set { orderLocation = value; }
        // }
        //The customer of the order
        public Customer orderCustomer { get; set;}
        // public Customer OrderCustomer
        // {
        //     get { return orderCustomer; }
        //     set { orderCustomer = value; }
        // }
        
        //Order time
        public DateTime timeCreated { get; set;}
        // public DateTime GetTimeCreated(){
        //     return timeCreated;
        // }

        //Calculate Price
        public void CostCalc() //Do in DB?
        {
            
        }

        public void DisplayDetails()
        {
            foreach(var item in orderProducts)
            {
            Console.WriteLine($"Order Id: {orderId} \tCustomer Id: {orderCustomer.userId} \tLocation: {orderLocation.locationName} \t "
            + $"Product: {item.description} \tProduct Quantity: {item.quantity} \t Price: {item.price} \t Time: {timeCreated}");
            }
        }
        

        public override string ToString()
        {
            return "Order Id: " + "Customer Id: " + "Location: " + "Product: " + "Product Quantity: " + "Cost: " + "Time of Order: ";
           
        }


        //Products in the order --List
        // private Product orderProducts;
        // public Product OrderProducts
        // {
        //     get { return orderProducts; }
        //     set { orderProducts = value; }
        // }
        
        
        
    }
}