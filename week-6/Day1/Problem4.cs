using System;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        public static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Payment verification started...");
            await Task.Delay(2000);
            Console.WriteLine("Payment verified.");
        }

        public static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Inventory check started...");
            await Task.Delay(2000);
            Console.WriteLine("Inventory available.");
        }

        public static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Order confirmation started...");
            await Task.Delay(2000);
            Console.WriteLine("Order confirmed.");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Order Processing Started...\n");

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("\nOrder Processing Completed Successfully!");
            Console.ReadLine();
        }
    }
}
