namespace Day3_problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            int marks;

            Console.WriteLine("Enter student name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Marks: ");
            marks = int.Parse(Console.ReadLine());

            if(marks<0 || marks>100)
            {
                Console.WriteLine("Marks should be enter between 0-100.");
            }
            else if(marks>=90)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: A");
            }
            else if(marks>=75)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: B");
            }
            else if(marks>=60)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: C");
            }
            else if(marks>=50)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: Fail");
            }
            Console.ReadLine();
        }
    }
}
