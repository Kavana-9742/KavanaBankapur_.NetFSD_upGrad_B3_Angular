namespace Product
{
    class Product
    {
        private string name;
        private double price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative.");
                }
                else
                {
                    price = value;
                }
            }
        }
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }
    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05); 
        }
    }
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Electronics Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product product;

            product = new Electronics();
            product.Price = price;
            Console.WriteLine("Final Price after 5% discount = " + product.CalculateDiscount());

            product = new Clothing();
            product.Price = price;
            Console.WriteLine("Final Price after 15% discount = " + product.CalculateDiscount());
        }
    }
}
