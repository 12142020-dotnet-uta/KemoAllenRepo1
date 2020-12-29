using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Order
    {
        public Order(){
            orderId = Guid.NewGuid();
            timeCreated = DateTime.Now;

        }

        //List containing the products in an order
        public List<Product> orderProducts = new List<Product>();

        public void AddToOrder(Product p)
        {
            orderProducts.Add(p);
        }

        //Order id
        private Guid orderId;
        public Guid OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        
        
        //The order's store location
        private Location orderLocation;
        public Location OrderLocation
        {
            get { return orderLocation; }
            set { orderLocation = value; }
        }
        //The customer of the order
        private Customer orderCustomer;
        public Customer OrderCustomer
        {
            get { return orderCustomer; }
            set { orderCustomer = value; }
        }
        
        //Order time
        private DateTime timeCreated;
        public DateTime GetTimeCreated(){
            return timeCreated;
        }

        //Calculate Price
        public void CostCalc()
        {
            
        }

        public void DisplayDetails()
        {
            foreach(var item in orderProducts)
            {
            Console.WriteLine($"Order Id: {orderId} \tCustomer Id: {orderCustomer.UserId} \tLocation: {orderLocation.LocationName} \t "
            + $"Product: {item.Description} \tProduct Quantity: {item.Quantity} \t Price: {item.Price} \t Time: {timeCreated}");
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