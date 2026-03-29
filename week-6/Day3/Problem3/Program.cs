namespace LSP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AreaCalculator calculator = new AreaCalculator();

            Shape rect = new Rectangle(10, 5);
            Shape circle = new Circle(7);

            calculator.PrintArea(rect);
            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
}
