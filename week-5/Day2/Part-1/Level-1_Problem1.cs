using System;
using System.Collections.Generic;

namespace Student
{
    public record Student(int RollNumber, string Name, string Course, int Marks);
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Console.Write("Enter number of students: ");
            int n;

            while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Invalid input! Enter a valid number: ");
            }

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");

                int roll;
                Console.Write("Enter Roll Number: ");
                while(!int.TryParse(Console.ReadLine(), out roll) || roll <= 0)
                {
                    Console.Write("Invalid Roll Number! Enter again: ");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                Console.Write("Enter Marks: ");
                while(!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
                {
                    Console.Write("Invalid Marks! Enter between 0-100: ");
                }
                students.Add(new Student(roll, name, course, marks));
            }
            int choice;

            do
            {
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid choice! Enter again: ");
                }

                switch (choice)
                {
                    case 1:
                        DisplayStudents(students);
                        break;

                    case 2:
                        SearchStudent(students);
                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            } while (choice != 3);
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("\nStudent Records:");
            if (students.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach(var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        static void SearchStudent(List<Student> students)
        {
            Console.Write("\nEnter Roll Number to search: ");
            int roll;

            while(!int.TryParse(Console.ReadLine(), out roll))
            {
                Console.Write("Invalid input! Enter again: ");
            }

            var student = students.Find(s => s.RollNumber == roll);

            Console.WriteLine("\nSearch Result: ");
            if(student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
    }
}
