//Problem 1: Simple Calculator Using Methods
namespace Calculator
{
    class Calculator
    {
        public int Add(int a , int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Enter a first number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second number:");
            int b = int.Parse(Console.ReadLine());
            int addResult = calc.Add(a, b);
            int subResult = calc.Subtract(a, b);
            Console.WriteLine("Addition= " + addResult);
            Console.WriteLine("Subtraction= " + subResult);
        }
    }
}
