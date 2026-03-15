//Problem 2: Student Grade Calculator
namespace StudentGrade
{
    class Student
    {
        public double CalculateAverage(int m1,int m2,int m3)
        {
            double avg = (m1 + m2 + m3) / 3;
            return avg;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine("Enter marks1: ");
            int m1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks2: ");
            int m2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks3: ");
            int m3 = int.Parse(Console.ReadLine());
            double average = s.CalculateAverage(m1, m2, m3);
            
            string grade;
            if (average >= 80)
            {
                grade = "A";
            }
            else if (average >= 60)
            {
                grade = "B";
            }
            else if (average >= 50)
            {
                grade = "C";
            }
            else
            {
                grade = "Fail";
            }
            Console.WriteLine("Average= " + average + ",Grade= " + grade);
        }
    }
}
