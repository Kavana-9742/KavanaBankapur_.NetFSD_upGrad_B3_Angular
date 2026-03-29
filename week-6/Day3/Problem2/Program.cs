namespace OCP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1000;

            Console.WriteLine("Regular Customer:");
            PriceCalculator regular = new PriceCalculator(new RegularCustomerDiscount());
            regular.CalculateFinalPrice(amount);

            Console.WriteLine("\nPremium Customer:");
            PriceCalculator premium = new PriceCalculator(new PremiumCustomerDiscount());
            premium.CalculateFinalPrice(amount);

            Console.WriteLine("\nVIP Customer:");
            PriceCalculator vip = new PriceCalculator(new VipCustomerDiscount());
            vip.CalculateFinalPrice(amount);

            Console.ReadLine();
        }
    }
}
