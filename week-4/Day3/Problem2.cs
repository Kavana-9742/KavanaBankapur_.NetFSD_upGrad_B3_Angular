namespace Day_3_Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter operator (+, -, *, /): ");
            char ope = char.Parse(Console.ReadLine());

            switch (ope)
            {
                case '+':
                    Console.WriteLine("Result: " + (num1 + num2));
                    break;
                case '-':
                    Console.WriteLine("Result: " + (num1 - num2));
                    break;
                case '*':
                    Console.WriteLine("Result: " + (num1 * num2));
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("cannot divide any number by zero.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + (num1 / num2));
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
