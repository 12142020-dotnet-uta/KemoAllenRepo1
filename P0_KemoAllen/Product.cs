namespace P0_KemoAllen
{
    public class Product
    {
        //Name of product
        private ProductList productName;
        public ProductList ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        
        //Price
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        
        //Description
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}