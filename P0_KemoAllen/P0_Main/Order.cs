using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Order
    {
        public Order(){

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
        // public List<Product> orderProducts = new List<Product>();

        // public void AddToOrder(Product p)
        // {
        //     orderProducts.Add(p);
        // }

        public Product orderProduct { get; set; }

        public int orderQuantity { get; set; }
        
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
        public DateTime timeCreated { get; set;} = DateTime.Now;
        // public DateTime GetTimeCreated(){
        //     return timeCreated;
        // }

        public void DisplayDetails()
        { 
            Console.WriteLine($"Order Id: {orderId} \tCustomer Id: {orderCustomer.userId} \tLocation: {orderLocation.LocationName} \t "
            + $"Product: {orderProduct.Description} \tProduct Quantity: {orderQuantity} \t Price: {orderProduct.UnitPrice} \t Time: {timeCreated}");
            
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