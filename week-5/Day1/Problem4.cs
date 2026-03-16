namespace Vehicle
{
    class Vehicle
    {
        private string brand;
        private double rentalRatePerDay;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rental rate cannot be negative.");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }
        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days.");
                return 0;
            }

            return rentalRatePerDay * days;
        }
    }
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days.");
                return 0;
            }
            double total = RentalRatePerDay * days;
            total += 500;
            return total;
        }
    }
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days.");
                return 0;
            }
            double total = RentalRatePerDay * days;
            total -= total * 0.05;
            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Car Rental Rate Per Day: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle;

            vehicle = new Car();
            vehicle.RentalRatePerDay = rate;
            Console.WriteLine("Car Total Rental = " + vehicle.CalculateRental(days));

            vehicle = new Bike();
            vehicle.RentalRatePerDay = rate;
            Console.WriteLine("Bike Total Rental (after 5% discount) = " + vehicle.CalculateRental(days));
        }
    }
}
