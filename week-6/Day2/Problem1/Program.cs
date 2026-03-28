using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                IConfiguration config = builder.Build();
                string conStr = config.GetConnectionString("DefaultConnection");

                ProductDAL dal = new ProductDAL(conStr);

                while (true)
                {
                    Console.WriteLine("1 Insert");
                    Console.WriteLine("2 View");
                    Console.WriteLine("3 Update");
                    Console.WriteLine("4 Delete");
                    Console.WriteLine("5 Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter Name:");
                        p.ProductName = Console.ReadLine();
                        Console.WriteLine("Enter Category:");
                        p.Category = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        p.Price = Convert.ToDecimal(Console.ReadLine());

                        dal.InsertProduct(p);
                    }
                    else if (choice == 2)
                    {
                        dal.ViewProducts();
                    }
                    else if (choice == 3)
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter Id:");
                        p.ProductId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        p.ProductName = Console.ReadLine();
                        Console.WriteLine("Enter Category:");
                        p.Category = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        p.Price = Convert.ToDecimal(Console.ReadLine());

                        dal.UpdateProduct(p);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Enter Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        dal.DeleteProduct(id);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

