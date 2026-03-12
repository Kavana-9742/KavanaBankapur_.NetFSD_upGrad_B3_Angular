namespace Day_3_Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            double salary, bonus, finalsalary;
            int experience;

            Console.WriteLine("Enter emp name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter salary: ");
            salary = double.Parse(Console.ReadLine());

            if (salary < 0)
            {
                Console.WriteLine("Salary cannot be negative.");
                return;
            }

            Console.WriteLine("Enter Experience(in years): ");
            experience = int.Parse(Console.ReadLine());

            if (experience < 0)
            {
                Console.WriteLine("Experience cannot be negative.");
                return;
            }

            double bonusPercent;

            if (experience < 2)
            {
                bonusPercent = 0.05;
            }
            else if (experience <= 5)
            {
                bonusPercent = 0.10;
            }
            else
            {
                bonusPercent = 0.15;
            }

            bonus = salary > 0 ? salary * bonusPercent : 0;
            finalsalary = salary + bonus;

            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Bonus: " + bonus.ToString("F2"));
            Console.WriteLine("Final Salary: " + finalsalary.ToString("F2"));

            Console.ReadLine();
        }
    }
}
