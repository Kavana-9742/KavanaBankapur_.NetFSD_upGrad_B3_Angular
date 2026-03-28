using System;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter discount percentage: ");
            double discount = double.Parse(Console.ReadLine());

            double discountAmount = price * discount / 100;
            double finalPrice = price - discountAmount;

            Console.WriteLine("Product: " + productName);
            Console.WriteLine("Original Price: " + price);
            Console.WriteLine("Discount: " + discount + "%");
            Console.WriteLine("Final Price: " + finalPrice);

            Console.ReadLine();
        }
    }
}
