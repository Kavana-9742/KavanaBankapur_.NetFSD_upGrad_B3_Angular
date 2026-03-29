namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            Console.WriteLine("Configuration Details:");
            Console.WriteLine(config1.ApplicationName);
            Console.WriteLine(config1.Version);
            Console.WriteLine(config1.DatabaseConnectionString);

            Console.WriteLine();

            // Check Singleton
            if (config1 == config2)
            {
                Console.WriteLine("Both objects are same instance (Singleton works)");
            }
            else
            {
                Console.WriteLine("Different instances");
            }

            Console.ReadLine();
        }
    }
}
