using System;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        public static async Task WriteLogAsync(string message)
        {
            Console.WriteLine("Writing log: " + message);

            await Task.Delay(2000);

            Console.WriteLine("Log written: " + message);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started");

            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Email sent");

            Console.WriteLine("Main thread is still running...");

            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("All logs completed");
        }
    }
}
