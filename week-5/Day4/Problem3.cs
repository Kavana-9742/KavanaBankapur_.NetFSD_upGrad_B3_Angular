using System;

namespace EmployeePerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Monthly Sales Amount: ");
                double sales = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Customer Feedback Rating (1-5): ");
                int rating = Convert.ToInt32(Console.ReadLine());

                if (sales < 0 || rating < 1 || rating > 5)
                {
                    Console.WriteLine("Invalid input values.");
                    return;
                }

                var data = GetEmployeeData(sales, rating);

                string performance = data switch
                {
                    ( >= 100000, >= 4) => "High Performer",
                    ( >= 50000, >= 3) => "Average Performer",
                    _ => "Needs Improvement"
                };

                Console.WriteLine("\n--- Employee Performance ---");
                Console.WriteLine("Employee Name : " + name);
                Console.WriteLine("Sales Amount  : " + data.sales);
                Console.WriteLine("Rating        : " + data.rating);
                Console.WriteLine("Performance   : " + performance);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numeric values correctly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static (double sales, int rating) GetEmployeeData(double sales, int rating)
        {
            return (sales, rating);
        }
    
    }
}
