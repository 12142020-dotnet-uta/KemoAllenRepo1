namespace P0_KemoAllen
{
    public class Order
    {
        //Order number
        
        //The order's store location
        private string orderLocation;
        public string OrderLocation
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

        //Products in the order --List
        private Product orderProducts;
        public Product OrderProducts
        {
            get { return orderProducts; }
            set { orderProducts = value; }
        }
        
        
    }
}