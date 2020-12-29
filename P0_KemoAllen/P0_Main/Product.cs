using System.ComponentModel.DataAnnotations;
using System;
namespace P0_KemoAllen
{
    public class Product
    {
        //Constructor
        public Product(){

        }
        public Product(string name, double price, int quantity){
            this.description = name;
            this.price = price;
            this.quantity = quantity;
        }
        //Product id
        [Key]
        public Guid productId {get; set;} = Guid.NewGuid();
        
        //Price
        public double price { get; set;}
        // public double Price
        // {
        //     get { return price; }
        //     set { price = value; }
        // }

        //Quantity
        public int quantity { get; set;}
        // public int Quantity
        // {
        //     get { return quantity; }
        //     set { quantity = value; }
        // }
        
        
        //Description
        public string description { get; set;}
        // public string Description
        // {
        //     get { return description; }
        //     set { description = value; }
        // }

        //
        public override string ToString()
        {
            return description;
        }
    }
}