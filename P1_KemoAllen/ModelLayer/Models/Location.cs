using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Location
    {
        public Location(){

        }
        public Location(string name){
            //Store name
            this.locationName = name;

        }
        //Location Id
        [Key]
        public Guid locationGuid { get; set;} = Guid.NewGuid();
        // public Guid LocationGuid
        // {
        //     get { return locationGuid; }
        //     set { locationGuid = value; }
        // }
        

        //Name of Loctation
        private string locationName { get; set;} 
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
        
        //Inventory of the location -- List
        //public Inventory locationInventory { get; set;} = new Inventory();
        // public Inventory LocationInventory
        // {
        //     get { return locationInventory; }
        //     set { locationInventory = value; }
        // }
        
        public override string ToString()
        {
            return locationName;
        }
        
    }
}