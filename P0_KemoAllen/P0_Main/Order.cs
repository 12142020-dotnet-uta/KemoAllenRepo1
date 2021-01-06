using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Order
    {
        public Order(){

        }

        public Order(Guid id, Customer user, Location location)
        {
            this.orderId = id;
            this.orderCustomer = user;
            this.orderLocation = location;
        }

        //Order id
        public Guid orderId { get; set;} 
        // public Guid OrderId
        // {
        //     get { return orderId; }
        //     set { orderId = value; }
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
        [Key]
        public DateTime timeCreated { get; set;} = DateTime.Now;
        // public DateTime GetTimeCreated(){
        //     return timeCreated;
        // }

        //Price
        private decimal price;

        public decimal getPrice()
        {
            return price;
        }
        public void CalculatePrice()
        {
            price = (decimal)orderQuantity * orderProduct.UnitPrice;
        }

        public void DisplayDetails()
        { 
            Console.WriteLine($"Order Id: {orderId} \tUser Name: {orderCustomer.UserName} \tLocation: {orderLocation.LocationName}"
            + $"\tProduct: {orderProduct.Description} \tProduct Quantity: {orderQuantity} \tPrice: {price} \tTime: {timeCreated}");
            
        }
        
        public override string ToString()
        {
            return "Order Id: " + "Customer Id: " + "Location: " + "Product: " + "Product Quantity: " + "Cost: " + "Time of Order: ";
           
        } 
        
    }
}