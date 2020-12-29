using System;
namespace P0_KemoAllen
{
    public class Location
    {
        public Location(){

        }
        public Location(string name){
            //Store Id
            locationName = name;
            //Initialize store location with an inventory
            locationInventory = new Inventory();
            
            //locationGuid = Guid.NewGuid();

            // locationInventory.LoadProducts();

            // Console.WriteLine(locationInventory.OrderProduct(1).ToString());

        }

        // private Guid locationGuid;
        // public Guid LocationGuid
        // {
        //     get { return locationGuid; }
        //     set { locationGuid = value; }
        // }
        

        //Name of Loctation
        private string locationName;
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
        
        //Inventory of the location -- List
        private Inventory locationInventory;
        public Inventory LocationInventory
        {
            get { return locationInventory; }
            set { locationInventory = value; }
        }
        

        
    }
}