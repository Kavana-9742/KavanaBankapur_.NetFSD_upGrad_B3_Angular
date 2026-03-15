/* Write  a  C# program to process product details using object oriented programming.
 
•	Class should contain private variables:  productId, productName, unitPrice, qty.
•	Constructor should allow productId as parameter
•	 Create properties for all private variables. Property Names :   ProductId, ProductName, UnitPrice, Quantity
•	ProductId – should be readonly property
•	ShowDetails()  method to display all the details along with total amount. */

namespace Product_details
{
    class Product
    {
        private int productId;
        private string productName;
        private double unitPrice;
        private int qty;

        public Product(int productId)
        {
            this.productId = productId;
        }

        public int ProductId
        {
            get { return productId; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int Quantity
        {
            get { return qty; }
            set { qty = value; }
        }

        public void ShowDetails()
        {
            double total = unitPrice * qty;

            Console.WriteLine("Product Id: " + productId);
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Unit Price: " + unitPrice);
            Console.WriteLine("Quantity: " + qty);
            Console.WriteLine("Total Amount: " + total);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product(101);
            p.ProductName = "Laptop";
            p.UnitPrice = 50000;
            p.Quantity = 2;

            p.ShowDetails();
        }
    }
}
