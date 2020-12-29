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

        //Name of product
        // private ProductList productName;
        // public ProductList ProductName
        // {
        //     get { return productName; }
        //     set { productName = value; }
        // }
        
        //Price
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        //Quantity
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
        
        //Description
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //
        public override string ToString()
        {
            return description;
        }
    }
}