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

        [Key]
        public Guid inventoryId {get; set;} = new Guid();

        public Product inventoryProduct {get; set;}

        public int inventoryQuantity {get; set;} = 100;
        
        
        
    }//Inventory
}//namespace
