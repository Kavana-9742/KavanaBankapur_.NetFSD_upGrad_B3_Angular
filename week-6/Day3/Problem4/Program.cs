namespace ISP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicPrinter basic = new BasicPrinter();
            basic.Print();

            Console.WriteLine();

            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.ReadLine();
        }
    }
}
