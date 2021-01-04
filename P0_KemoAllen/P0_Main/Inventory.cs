using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace P0_KemoAllen
{
    public class Inventory
    {
        public Inventory(){

        }
        //use this to keep track of quantity

        public Inventory(Product product, Location location)
        {
            this.inventoryProduct = product;
            this.inventoryLocation = location;
        }

        [Key]
        public Guid inventoryId {get; set;} = new Guid();

        public Product inventoryProduct {get; set;}

        public int inventoryQuantity {get; set;} = 100;

        public Location inventoryLocation {get; set;}
        
        
    }//Inventory
}//namespace
