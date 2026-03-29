using System;
using System.Collections.Generic;
using System.Text;

namespace SRP_Example
{
    internal class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student.StudentId <= 0)
            {
                Console.WriteLine("Invalid Student ID");
                return;
            }

            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                Console.WriteLine("Invalid Student Name");
                return;
            }

            if (student.Marks < 0 || student.Marks > 100)
            {
                Console.WriteLine("Marks must be between 0 and 100");
                return;
            }

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
